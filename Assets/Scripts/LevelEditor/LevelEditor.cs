using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditor : MonoBehaviour
{
    // Drag in what beatmap you want to update through unity editor
    public BeatMap beatMap;
    private AudioSource audioSource;

    private bool paused = true;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = beatMap.Song;
        PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(paused) { 
                PlayMusic();
            } else {
                PauseMusic();
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            ArrayList note = new ArrayList();
            note.Add(audioSource.time);
            note.Add(1);
            beatMap.AddBeat(note);
        }
    }

    private void PlayMusic()
    {
        paused = false;
        audioSource.Play();
    }

    private void PauseMusic() 
    {
        paused = true;
        audioSource.Pause();
    }
}
