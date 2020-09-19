using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawn : MonoBehaviour
{
    public Transform[] spawns;

    public GameObject note;

    public ScoreAndComboCounter counter;

    private Score scoreKeeper;

    private AudioSource source;

    public AudioClip slap;

    private GameObject[] nextNotes;

    private bool canSpawn;

    public int maxHp, dmg;
    
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = slap;
        scoreKeeper = new Score(maxHp, dmg);
        counter.scoreKeeper = scoreKeeper;
        canSpawn = true;
        nextNotes = new GameObject[2];
        for (int i = 0; i < 2; i++)
        {
            nextNotes[i] = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
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
        // Not final way to make beats, need to figure out way to choose the row we want
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
    }
}
