using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongSelectScript : MonoBehaviour
{
    public GameObject credits, selectMenu, controls;
    
    public void Caramelldansen()
    {
        StartCoroutine("ChangeToCaramell");
    }

    public void NeverGonnaGiveYouUp()
    {
        StartCoroutine("RickRoll");
    }

    IEnumerator ChangeToCaramell()
    {
        AsyncOperation load = SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
        yield return load;
        SceneManager.UnloadSceneAsync("SongSelect");
    }

    IEnumerator RickRoll()
    {
        AsyncOperation load = SceneManager.LoadSceneAsync("RickRoll", LoadSceneMode.Single);
        yield return load;
        SceneManager.UnloadSceneAsync("SongSelect");
    }

    public void CreditButton()
    {
        selectMenu.SetActive(false);
        credits.SetActive(true);
    }

    public void GoBack()
    {
        selectMenu.SetActive(true);
        credits.SetActive(false);
    }

    public void Controls()
    {
        controls.SetActive(true);
        selectMenu.SetActive(false);
    }

    public void GoBackFromControls()
    {
        controls.SetActive(false);
        selectMenu.SetActive(true);
    }
}
