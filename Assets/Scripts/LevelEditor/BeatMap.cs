using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BeatMap", order = 1)]
public class BeatMap : ScriptableObject
{
    private ArrayList Beats = new ArrayList();
    public AudioClip Song;

    private BeatComparer beatComparer = new BeatComparer();


    private class BeatComparer : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            ArrayList a = (ArrayList)x;
            ArrayList b = (ArrayList)y;
            if((float)a[0] > (float)b[0]){
                return 1;
            } else if((float)a[0] < (float)b[0]) {
                return -1;
            } else{
                return 0;
            }
        }
    }    
    public void AddBeat(ArrayList note) 
    {
        Beats.Add(note);
        Beats.Sort(beatComparer);
    }

    // Unity stupid and doesnt support tuples
    // Arraylist is used in place of Tuple<float, int>
    public Queue<ArrayList> GetBeats() 
    {
        Queue<ArrayList> beats = new Queue<ArrayList>();
        foreach (ArrayList beat in Beats)
        {
            beats.Enqueue(beat);
        }
        return beats;
    }

}
