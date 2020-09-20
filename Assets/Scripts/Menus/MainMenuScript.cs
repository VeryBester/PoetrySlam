using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    private void Start() {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainMenu"));
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            StartCoroutine("SwitchToPlay");
        }
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
}