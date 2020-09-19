using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCanvas : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsMenu;
    public GameObject MainMenuBackground;

    public bool toggle;

    // Start is called before the first frame update
    void Start()
    {
        if (!toggle) {
            MainMenu.SetActive(false);
            CreditsMenu.SetActive(false);
            MainMenuBackground.SetActive(false);

        } else {
            MainMenuButton();
        }
    }

    public void PlayNowButton()
    {
        // switch to game scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void CreditsButton()
    {
        // Show Credits Menu
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    public void MainMenuButton()
    {
        // Show Main Menu
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}