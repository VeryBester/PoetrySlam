using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsMenu;
    public GameObject MainMenuBackground;

    //public bool toggle_mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
        
        /*
        if (!toggle_mainMenu) {
            MainMenu.SetActive(false);
            CreditsMenu.SetActive(false);
            MainMenuBackground.SetActive(false);
        } else {
            SceneManager.UnloadSceneAsync("SampleScene");
            MainMenuButton();
        } */
    }

    IEnumerator SwitchToPlay()
    {
        AsyncOperation load = SceneManager.LoadSceneAsync("SongSelect", LoadSceneMode.Single);
        yield return load;
        SceneManager.UnloadSceneAsync("MainMenu");
    }

    public void PlayNowButton()
    {
        // switch to game scene
        StartCoroutine("SwitchToPlay");
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