using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayOptions : MonoBehaviour
{
    public Text normalHighscoreText;
    public Text crazyHighscoreText;

    public int NormalHS;
    public int CrazyHS;
    public static int resetScore = 0;

    private void Update()
    {
        // PlayerPrefs gets set into a variable.
        this.NormalHS = PlayerPrefs.GetInt("highscore");
        this.CrazyHS = PlayerPrefs.GetInt("CrazyHighscore");

        // The variable used to change the HS text. 
        this.normalHighscoreText.text = "Normal HS: " + NormalHS;
        this.crazyHighscoreText.text = "Crazy HS: " + CrazyHS;

        // Resets Normal Highscore by pressing the 'L' on the keyboard.
        if (Input.GetKey(KeyCode.L))
        {
            // Saves the reset highscore.
            PlayerPrefs.SetInt("highscore", resetScore);

            // The highscore text chages when button is pressed.
            this.normalHighscoreText.text = "Normal HS: " + this.NormalHS;
        }
        // Resets Crazy Highscore by pressing the 'L' on the keyboard.
        if (Input.GetKey(KeyCode.O))
        {
            PlayerPrefs.SetInt("CrazyHighscore", resetScore);
            this.crazyHighscoreText.text = "Crazy HS: " + this.CrazyHS;
        }

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
