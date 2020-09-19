using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BeatMap", order = 1)]
[System.Serializable]
public class BeatMap : ScriptableObject
{
    public ArrayList Beats = new ArrayList();
    public AudioClip Song;
    public string Name;

    private static BeatComparer beatComparer = new BeatComparer();

    // Class for custom sort
    private class BeatComparer : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            NoteData a = (NoteData)x;
            NoteData b = (NoteData)y;
            if(a.time > b.time){
                return 1;
            } else if(a.time < b.time) {
                return -1;
            } else{
                return 0;
            }
        }
    }

    private void Awake() {
        LoadBeatMap();
    }    
    public void AddBeat(NoteData note) 
    {
        Beats.Add(note);
        Beats.Sort(beatComparer);
    }

    // Unity stupid and doesnt support tuples
    // Arraylist is used in place of Tuple<float, int>
    public Queue<NoteData> GetBeats() 
    {
        Queue<NoteData> beats = new Queue<NoteData>();
        foreach (NoteData beat in Beats)
        {
            beats.Enqueue(beat);
        }
        return beats;
    }

    public void SaveBeatMap()
    {
        object[] objArray = Beats.ToArray();
        NoteData[] notes = new NoteData[objArray.Length];
        for(int i = 0; i < objArray.Length; ++i)
        {
            NoteData note = (NoteData)objArray[i];
            notes[i] = note;
        }
        
        string json = JsonHelper.ToJson(notes);
        string filePath = Application.dataPath +"/BeatMaps/Json/" + Name +".json";
        File.WriteAllText(filePath, json);
    }

    public void LoadBeatMap()
    {
        string filePath = Application.dataPath +"/BeatMaps/Json/" + Name +".json";
        if(File.Exists(filePath))
        {
            StreamReader reader = new StreamReader(filePath);
            NoteData[] notes = JsonHelper.FromJson<NoteData>(reader.ReadToEnd());

            ArrayList loadedBeatMap = new ArrayList();
            foreach(NoteData note in notes)
            {
                loadedBeatMap.Add(note);
            }

            Beats = loadedBeatMap;
        }
    }

}
