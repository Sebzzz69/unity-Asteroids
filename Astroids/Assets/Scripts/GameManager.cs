using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;

    public ParticleSystem explotion;

    public float respawnTime = 3.0f;
    public float respawnInvunlnerabilityTime = 3.0f;

    public int lives = 3;
    public int score = 0;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void AsteroidDestroyed(Asteroid asteroid)
    {
        //Particle effect
        this.explotion.transform.position = asteroid.transform.position;
        this.explotion.Play();

        if (asteroid.size < 0.75f) {
            score += 100;
        } else if (asteroid.size < 1.2f) {
            score += 50;
        } else {
            this.score += 25;
        }
    }
     
    public void PlayerDied()
    {
        this.explotion.transform.position = this.player.transform.position;
        this.explotion.Play();

        this.lives--;

        if (this.lives <= 0){
            GameOver();
        } else
        {
            Invoke(nameof(Respawn), respawnTime);
        }

    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("Asteroids");
    }

    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        this.player.gameObject.SetActive(true);
        
        Invoke(nameof(TurnOnCollisions), respawnInvunlnerabilityTime);
    }

    private void TurnOnCollisions()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver()
    {
        this.lives = 3;
        this.score = 0;

        Invoke(nameof(Respawn), respawnTime);
        ReloadScene();
        
    }

}
