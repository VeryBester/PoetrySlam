using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public GameObject background;

    private GameObject[] backgrounds;

    private void Start()
    {
        backgrounds = new GameObject[2];
        backgrounds[0] = Instantiate(background);
        CreateNextBackground();
    }

    private void Update()
    {
        if (backgrounds[0] == null)
        {
            backgrounds[0] = backgrounds[1];
            CreateNextBackground();
        }
    }

    private void CreateNextBackground()
    {
        float objectWidth = background.GetComponent<SpriteRenderer>().bounds.size.x;
        GameObject clone = Instantiate(background);
        clone.transform.position = new Vector3(backgrounds[0].transform.position.x + objectWidth, background.transform.position.y, background.transform.position.z);
        backgrounds[1] = clone;
    }
}
