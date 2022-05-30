using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayOptions : MonoBehaviour
{
    public Text normalHighscoreText;
    public Text crazyHighscoreText;

    // TODO: 
    // Highscore for both gamemodes


    private void Start()
    {
        this.normalHighscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highscore");
    }

    public void Normal()
    {
        SceneManager.LoadScene("Asteroids");
    }

    public void Crazy()
    {
        SceneManager.LoadScene("CrazyAsteroids");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
