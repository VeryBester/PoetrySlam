using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongSelectScript : MonoBehaviour
{
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
}
