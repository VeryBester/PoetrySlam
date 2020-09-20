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
        beatMap.LoadBeatMap();
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

        bool topPressed = false;
        bool botPressed = false;
        
        if(Input.GetKeyDown(GameConstants.topButton1) || Input.GetKeyDown(GameConstants.topButton2))
        {
            topPressed = true;
        }
        
        if(Input.GetKeyDown(GameConstants.botButton1) || Input.GetKeyDown(GameConstants.botButton2))
        {
            botPressed = true;
        }


        if(topPressed || botPressed)
        {
            NoteData note = new NoteData();
            note.time = audioSource.time;
            note.topNote = topPressed;
            note.botNote = botPressed;
            beatMap.AddBeat(note);
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            beatMap.SaveBeatMap();
            Debug.Log("Saving");
        }
    }


    private void PlayMusic()
    {
        paused = false;
        
        //TODO commentated out for sanity

        audioSource.Play();
    }

    private void PauseMusic() 
    {
        paused = true;
        audioSource.Pause();
    }

}
