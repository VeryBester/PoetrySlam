using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawn : MonoBehaviour
{
    public Transform[] spawns;

    public GameObject note;

    private Score scoreKeeper;

    private GameObject[] nextNotes;

    private bool canSpawn;

    public int maxHp, dmg;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = new Score(maxHp, dmg);
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
            print("u suck");
        }
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject temp = Instantiate(note);
            temp.SetActive(true);
            temp.transform.position = spawns[i].position;
            temp.GetComponent<Note>().nextNote = nextNotes[i];
            temp.GetComponent<Note>().bpm = 5;
            temp.GetComponent<Note>().scoreKeeper = scoreKeeper;
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
        yield return new WaitForSeconds(1f);
        canSpawn = true;
    }
}
