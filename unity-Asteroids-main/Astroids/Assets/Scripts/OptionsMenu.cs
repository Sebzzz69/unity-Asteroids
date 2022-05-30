using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;

    public static bool isOptionsMenu = false;

    private void Update()
    {
        if (isOptionsMenu == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Back();
            }
        }
    }

    public void Back()
    {
        this.optionsMenuUI.SetActive(false);
        this.pauseMenuUI.SetActive(true);
        isOptionsMenu = false;
    }

    public void OptionMenu()
    {
        isOptionsMenu = true;
        this.pauseMenuUI.SetActive(false);
        this.optionsMenuUI.SetActive(true);

    }

}
