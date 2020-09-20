using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class GameController : MonoBehaviour
{
    
    public AudioSource slap;
    private AudioSource music;
    private Queue<NoteData> beats;
    private Queue<NoteData> topActiveBeats;
    private Queue<NoteData> botActiveBeats;
    private Queue<GameObject> topNoteVisuals;
    private Queue<GameObject> botNoteVisuals;
    private Score scoreKeeper;
    public ScoreAndComboCounter counter;
    public GameObject noteVisual;
    public Button goBack;
    public GameObject haiku, scoreBack;

    public Transform[] spawns;

    public float startTime = 2f;
    public float spawnDelay = 2f;

    public float perfectTime;
    public float goodTime;
    public float lateTime;

    public int perfectScore = 300;
    public int goodScore = 100;
    public int lateScore = 50;

    public float expireTime;

    private bool startGame = false;
    public int maxHp, dmg;


    public BeatMap BeatMap;
    private void Awake() {
        BeatMap.LoadBeatMap();
        beats = BeatMap.GetBeats();
        
        music = GetComponent<AudioSource>();
        music.clip = BeatMap.Song;

        scoreKeeper = new Score(maxHp, dmg);
        counter.scoreKeeper = scoreKeeper;

        topActiveBeats = new Queue<NoteData>();
        botActiveBeats = new Queue<NoteData>();

        topNoteVisuals = new Queue<GameObject>();
        botNoteVisuals = new Queue<GameObject>();
        StartCoroutine("StartGame");
    }

    private void Update() {
        SpawnNotes();
        ClearExpiredNotes();
        KeyPresses();

        if (scoreKeeper.GetHealth() <= 0)
        {
            // TODO: Insert deleting executable here
            // print("u suck");
        }
    }

    IEnumerator StartGame()
    {
        // Gives time for notes to load in
        yield return new WaitForSeconds(Mathf.Max(startTime - spawnDelay, 0f));
        startGame = true;
        music.Play();
        
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(4f);
        haiku.SetActive(true);
        yield return new WaitForSeconds(4f);
        haiku.SetActive(false);
        goBack.gameObject.SetActive(true);
        scoreBack.SetActive(true);
        Time.timeScale = 0;
    }

    private void SpawnNotes()
    {
        if(startGame)
        {
            if(beats.Count > 0)
            {
                NoteData nextNote = beats.Peek();
                if(Mathf.Abs(music.time - nextNote.time) < 0.1f)
                {
                    beats.Dequeue();
                    if(nextNote.topNote)
                    {
                        GameObject note = GenerateNote();
                        note.transform.position = spawns[0].position;
                        topActiveBeats.Enqueue(nextNote);
                        topNoteVisuals.Enqueue(note);
                    } 
                    if(nextNote.botNote)
                    {
                        GameObject note = GenerateNote();
                        note.transform.position = spawns[1].position;
                        botActiveBeats.Enqueue(nextNote);
                        botNoteVisuals.Enqueue(note);
                    }
                    
                }
            }
            else
            {
                StartCoroutine("EndGame");
            }
        }
    }

    private GameObject GenerateNote()
    {
        GameObject note = Instantiate(noteVisual);
        note.SetActive(true);
        note.GetComponent<Note>().bpm = 6;
        note.GetComponent<Note>().scoreKeeper = scoreKeeper;
        return note;
    }

    // Deletes unreachable late notes
    private void ClearExpiredNotes()
    {
        float currentTime = music.time - startTime;
        
        bool topUpdated = false;
        while(!topUpdated && topActiveBeats.Count > 0)
        {
            NoteData note = topActiveBeats.Peek();
            float timeDiff = currentTime - note.time;
            if(timeDiff > lateTime)
            {
                Debug.Log(timeDiff);
                topActiveBeats.Dequeue();
                GameObject noteVisual = topNoteVisuals.Peek();
                topNoteVisuals.Dequeue();
                Destroy(noteVisual);
                scoreKeeper.UpdateScore(0);
            }
            else{
                topUpdated = true;
            }
        }


        bool botUpdated = false;
        while(!botUpdated && botActiveBeats.Count > 0)
        {
            NoteData note = botActiveBeats.Peek();
            float timeDiff = currentTime - note.time;
            if(timeDiff > lateTime)
            {
                botActiveBeats.Dequeue();
                GameObject noteVisual = botNoteVisuals.Peek();
                botNoteVisuals.Dequeue();
                Destroy(noteVisual);
                scoreKeeper.UpdateScore(0);
            }
            else{
                botUpdated = true;
            }
        }
    }

    private void KeyPresses()
    {
        if(Input.GetKeyDown(GameConstants.topButton1) || Input.GetKeyDown(GameConstants.topButton2))
        {
            if(topActiveBeats.Count > 0)
            {
                float currentTime = music.time - startTime;
                
                NoteData note = topActiveBeats.Peek();
                float timeDiff = Mathf.Abs(currentTime - note.time);

                if(timeDiff > lateTime){
                    scoreKeeper.UpdateScore(0);
                }
                else
                {
                    int score = 0;
                    if(timeDiff < perfectTime){
                        score = perfectScore;
                    } 
                    else if(timeDiff < goodTime)
                    {
                        score = goodScore;
                    }
                    else{
                        score = lateScore;
                    }
                    
                    topActiveBeats.Dequeue();
                    GameObject noteVisual = topNoteVisuals.Peek();
                    topNoteVisuals.Dequeue();
                    Destroy(noteVisual);
                    scoreKeeper.UpdateScore(score);
                    slap.Play();
                }
            }
        }

        if(Input.GetKeyDown(GameConstants.botButton1) || Input.GetKeyDown(GameConstants.botButton2))
        {
            if(botActiveBeats.Count > 0)
            {
                float currentTime = music.time - startTime;
                
                NoteData note = botActiveBeats.Peek();
                float timeDiff = Mathf.Abs(currentTime - note.time);
                
                if(timeDiff > lateTime){
                    scoreKeeper.UpdateScore(0);
                }
                else
                {
                    int score = 0;
                    if(timeDiff < perfectTime){
                        score = perfectScore;
                    } 
                    else if(timeDiff < goodTime)
                    {
                        score = goodScore;
                    }
                    else{
                        score = lateScore;
                    }
                    
                    botActiveBeats.Dequeue();
                    GameObject noteVisual = botNoteVisuals.Peek();
                    botNoteVisuals.Dequeue();
                    Destroy(noteVisual);
                    scoreKeeper.UpdateScore(score);
                    slap.Play();
                }
            }
        }
    }
}
