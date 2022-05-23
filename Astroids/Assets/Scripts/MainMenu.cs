using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject Main;
    public GameObject optionsMenu;

    public void Play()
    {
        SceneManager.LoadScene("Asteroids");
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
