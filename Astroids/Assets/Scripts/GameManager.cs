using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Variables
    public Player player;
    public GameOverScreen GameOverScreen;

    public ParticleSystem explotion;

    public Text scoreText;
    public Text lifeText;

    private bool _gameOver;

    public float respawnTime = 3.0f;
    public float respawnInvunlnerabilityTime = 3.0f;

    public int currentLives = 3;
    public int currentScore;
    #endregion
        
    private void Start()
    {
        _gameOver = false;

        currentScore = 0;
        currentLives = 3;

        lifeText.text = "x " + currentLives;

        DontDestroyOnLoad(this.gameObject);
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
        lifeText.text = "x " + currentLives;

        if (this.currentLives <= 0){
            GameOver();
        } else
        {
            Invoke(nameof(Respawn), respawnTime);
        }

    }

    private void HandleScore()
    {
        scoreText.text = "" + currentScore;
    }

    //private void ReloadScene()
    //{
    //    SceneManager.LoadScene("Asteroids");
    //}

    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        this.player.gameObject.SetActive(true);
        this.player.shouldShoot = false;

        Invoke(nameof(TurnOnShoot), respawnInvunlnerabilityTime);
        Invoke(nameof(TurnOnCollisions), respawnInvunlnerabilityTime);
    }

    private void TurnOnCollisions()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void TurnOnShoot()
    {
        this.player.shouldShoot = true;
    }

    //private void GameOver()
    //{
    //    _gameOver = true;

    //    if (_gameOver)
    //    {
    //        var asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
    //        foreach (var asteroid in asteroids)
    //        {
    //            Destroy(asteroid);
    //        }
    //    }

    //    this.currentLives = 3;
    //    lifeText.text = "x " + currentLives;

    //    this.currentScore = 0;
    //    HandleScore();

    //    Invoke(nameof(Respawn), respawnTime);
    //    ReloadScene();
        
    //}

    private void GameOver()
    {
        GameOverScreen.Setup(currentScore);
    }


}
