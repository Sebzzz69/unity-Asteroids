using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Return))
        {
            RestartGame();
        }
    }

    public void Setup(int score)
    {
        // Activating the Gameover screen and shows score
        gameObject.SetActive(true);
        this.scoreText.text = score.ToString() + " POINTS";
        this.highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highscore");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Asteroids");
    }

}
