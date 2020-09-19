using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject PauseMenu;
    public Button pause_button;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
    }

    public void PauseButton()
    {
        PauseMenu.SetActive(true);
        pause_button.interactable = false;
        // TODO: somehow pause actual game
        
    }

    public void ResumeButton()
    {
        PauseMenu.SetActive(false);
        pause_button.interactable = true;
        // TODO: reverse of above 
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
