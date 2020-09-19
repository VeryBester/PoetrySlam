using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject OptionsMenu;
    public Button Pause_Button;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        OptionsMenu.SetActive(false);
    }

    public void PauseButton()
    {
        PauseMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        // TODO: somehow pause actual game
    }

    public void ResumeButton()
    {
        PauseMenu.SetActive(false);
        // TODO: reverse of above 
    }

    public void OptionsButton()
    {
        PauseMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }


    public void QuitButton()
    {
        // switch to game scene
        StartCoroutine(SwitchToMain());
    }

    IEnumerator SwitchToMain()
    {
        AsyncOperation load = SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
        yield return load;
        SceneManager.UnloadSceneAsync("SampleScene");
    }
}
