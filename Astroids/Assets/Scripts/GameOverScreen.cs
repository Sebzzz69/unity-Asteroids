using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            RestartGame();
        }
    }

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        this.scoreText.text = score.ToString() + " POINTS";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Asteroids");
    }

    public void ExitGame()
    {
        // TODO
    }

}
