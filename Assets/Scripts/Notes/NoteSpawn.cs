using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawn : MonoBehaviour
{
    public Transform[] spawns;

    public GameObject note;

    public ScoreAndComboCounter counter;

    public AudioClip slap;

    public BeatMap map;

    public AudioSource musicPlayer;

    public int maxHp, dmg;

    private Score scoreKeeper;

    private AudioSource source;

    private GameObject[] nextNotes;

    private Queue<NoteData> notes;

    private bool canSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = slap;
        scoreKeeper = new Score(maxHp, dmg);
        counter.scoreKeeper = scoreKeeper;
        canSpawn = true;
        nextNotes = new GameObject[2];
        map.LoadBeatMap();
        notes = map.GetBeats();
        musicPlayer.clip = map.Song;
        musicPlayer.PlayDelayed(2f);
        for (int i = 0; i < 2; i++)
        {
            nextNotes[i] = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn && notes.Count > 0)
        {
            StartCoroutine("Spawn");
        }

        if (scoreKeeper.GetHealth() <= 0)
        {
            // Insert deleting executable here
            // print("u suck");
        }
    }

    IEnumerator Spawn()
    {
        NoteData noteData = notes.Dequeue();
        GameObject temp = Instantiate(note);
        temp.SetActive(true);
        temp.GetComponent<Note>().bpm = 6;
        temp.GetComponent<Note>().scoreKeeper = scoreKeeper;
        temp.GetComponent<Note>().audioSource = source;
        if (noteData.topNote)
        {
            if (noteData.botNote)
            {
                // Spawn 2
                GameObject secondNote = Instantiate(temp);
                temp.GetComponent<Note>().isTopRow = true;
                temp.transform.position = spawns[0].position;
                temp.GetComponent<Note>().nextNote = nextNotes[0];
                nextNotes[0] = temp;

                secondNote.GetComponent<Note>().isTopRow = false;
                secondNote.transform.position = spawns[1].position;
                secondNote.GetComponent<Note>().nextNote = nextNotes[1];
                nextNotes[1] = secondNote;
            }
            else
            {
                temp.GetComponent<Note>().isTopRow = true;
                temp.transform.position = spawns[0].position;
                temp.GetComponent<Note>().nextNote = nextNotes[0];
                nextNotes[0] = temp;
            }
        }
        else if (noteData.botNote)
        {
            temp.GetComponent<Note>().isTopRow = false;
            temp.transform.position = spawns[1].position;
            temp.GetComponent<Note>().nextNote = nextNotes[1];
            nextNotes[1] = temp;
        }

        canSpawn = false;
        yield return new WaitForSeconds(notes.Peek().time - noteData.time);
        canSpawn = true;

        // Not final way to make beats, need to figure out way to choose the row we want
        /*
        for (int i = 0; i < 2; i++)
        {
            GameObject temp = Instantiate(note);
            temp.SetActive(true);
            temp.transform.position = spawns[i].position;
            temp.GetComponent<Note>().nextNote = nextNotes[i];
            temp.GetComponent<Note>().bpm = 5;
            temp.GetComponent<Note>().scoreKeeper = scoreKeeper;
            temp.GetComponent<Note>().audioSource = source;
            if (i == 0)
            {
                temp.GetComponent<Note>().isTopRow = true;
            }
            else
            {
                temp.GetComponent<Note>().isTopRow = false;
            }

            nextNotes[i] = temp;
        }
        canSpawn = false;
        // Not final way to make beats, just needed something to test stuff with
        yield return new WaitForSeconds(1f);
        canSpawn = true;
        */
    }
}
