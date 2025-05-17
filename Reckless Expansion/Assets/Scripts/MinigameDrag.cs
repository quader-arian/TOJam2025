using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MinigameDrag : MonoBehaviour
{
    public GameObject[] minigames;
    private Vector3 [] originalPos;
    public int hits;
    private Color originalColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = new Vector3[minigames.Length];
        int i = 0;
        foreach(GameObject g in minigames)
        {
            originalPos[i] = g.transform.position;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.parent.gameObject.GetComponent<MalfunctionController>().ChangeColor(Color.red, transform.parent.gameObject);
        Camera.main.GetComponent<Camera>().backgroundColor = Color.red;

        //Debug.Log(check);
        bool check = true;
        for (int i = 0; i < minigames.Length; i=i+2)
        {
            check = check && (minigames[i].transform.position == minigames[i + 1].transform.position);
        }

        if (check)
        {
            int i = 0;
            foreach (GameObject g in minigames)
            {
                g.transform.position = originalPos[i];
                i++;
            }
            transform.parent.gameObject.GetComponent<MalfunctionController>().OffMinigame(originalColor, gameObject);
        }
    }
}
