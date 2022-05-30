using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Variables
    public Player player;
    public AsteroidSpawner asteroidspawner;
    public GameOverScreen GameOverScreen;
    public PlayOptions _playOptions;

    public ParticleSystem explotion;

    public Text scoreText;
    public Text lifeText;

    public bool crazyAsteroids;

    public float respawnTime = 3.0f;
    public float respawnInvulnerabilityTime = 3.0f;

    public int currentLives = 3;
    public int currentScore;
    public int currentScoreCrazy;
    #endregion
        
    private void Start()
    {

        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene. 
        string sceneName = currentScene.name;


        // Sets a boolean to determine whether gamemode "Crazy Asteroids" is 
        // Active or not depending on which scene is active. 
        if (sceneName == "Asteroids")
        {
            this.crazyAsteroids = false;
        }
        else if (sceneName == "CrazyAsteroids")
        {
            this.crazyAsteroids = true;
        }

        // Resets score and lives
        this.currentScore = 0;
        this.currentScoreCrazy = 0;
        this.currentLives = 3;

        // Updates Lives to 3 
        this.lifeText.text = "x " + currentLives;

    }

    private void Update()
    {

        if (crazyAsteroids == true)
        {
            this.asteroidspawner.spawnRate = 0.2f;
            this.asteroidspawner.spawnAmount = 5;
        }

        // If the boolean is true.
        if (!crazyAsteroids)
        {
            // Spawning more asteroids after a set amount of score.
            if (currentScore > 1000)
            {
                this.asteroidspawner.spawnRate = 1.0f;
            } else if (currentScore > 1500)
            {
                this.asteroidspawner.spawnRate = 0.5f;
            } else if (currentScore > 2000)
            {
                this.asteroidspawner.spawnRate = 0.3f;
                this.asteroidspawner.spawnAmount = 2;
            } else if (currentScore > 3000)
            {
                this.asteroidspawner.spawnRate = 0.3f;
                this.asteroidspawner.spawnAmount = 3;
            } else if (currentScore > 10000)
            {
                this.asteroidspawner.spawnRate = 0.6f;
                this.asteroidspawner.spawnAmount = 3;
            }
        }
        
    }


    public void AsteroidDestroyed(Asteroid asteroid)
    {
        //Particle effect
        this.explotion.transform.position = asteroid.transform.position;
        this.explotion.Play();

        if (asteroid.size < 0.75f) {
            currentScore += 100;
            HandleScore();
        } else if (asteroid.size < 1.2f) {
            currentScore += 50;
            HandleScore();
        } else {
            this.currentScore += 25;
            HandleScore();
        }
    }
     
    public void PlayerDied()
    {
        this.explotion.transform.position = this.player.transform.position;
        this.explotion.Play();

        this.currentLives--;
       this.lifeText.text = "x " + this.currentLives;

        if (this.currentLives <= 0){
            GameOver();
        } else
        {
            Invoke(nameof(Respawn), respawnTime);
        }

    }

    private void HandleScore()
    {
        if (this.crazyAsteroids)
        {
            this.currentScoreCrazy = this.currentScore / 3;
            this.currentScoreCrazy = this.currentScoreCrazy * 2;
        }

        // Updates score when this funtion is called.
        this.scoreText.text = "" + this.currentScore;
    }

    private void Respawn()
    {
        // Reset values of "Player" to respawn
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        this.player.gameObject.SetActive(true);
        this.player.shouldShoot = false;

        // 2 functions gets called when the player respawns after a set amount of seconds. 
        Invoke(nameof(TurnOnShoot), respawnInvulnerabilityTime);
        Invoke(nameof(TurnOnCollisions), respawnInvulnerabilityTime);
    }

    private void TurnOnCollisions()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void TurnOnShoot()
    {
        this.player.shouldShoot = true;
    }

    private void GameOver()
    {
        // If the "currentScore" is greater than "highscore", then current score
        // will become the highscore. It's being saved as "PlayerPrefs"
        if (!this.crazyAsteroids)
        {
            if (this.currentScore > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", this.currentScore);
            }
        }
        // Does the same thing here except in the Crazy Gamemode.
        if (this.crazyAsteroids)
        {
            if (this.currentScoreCrazy > PlayerPrefs.GetInt("CrazyHighscore"))
            {
                PlayerPrefs.SetInt("CrazyHighscore", this.currentScoreCrazy);
            }
        }

        GameOverScreen.Setup(currentScore);
    }


}
