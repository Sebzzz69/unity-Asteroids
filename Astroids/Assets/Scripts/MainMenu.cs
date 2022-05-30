using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public GameObject Main;
    public GameObject optionsMenu;

    public Text highscoreText;

    public void Play()
    {
        SceneManager.LoadScene("PlayOptions");
    }

    public void Options()
    {
        this.Main.SetActive(false);
        this.optionsMenu.SetActive(true);
    }

    public void Back()
    {
        this.optionsMenu.SetActive(false);
        this.Main.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
