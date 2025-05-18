using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameDrag : MonoBehaviour
{
    public GameObject[] minigames;
    private Vector3 [] originalPos;
    private Color[] originalCol;
    public int hits;
    private Color originalColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = new Vector3[minigames.Length];
        originalCol = new Color[minigames.Length];
        for (int i = 0; i < minigames.Length; i++)
        {
            originalPos[i] = minigames[i].transform.position;
            originalCol[i] = minigames[i].GetComponent<Renderer>().material.color;
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
            check = check && (minigames[i].transform.position == minigames[i + 1].transform.position && !minigames[i+1].GetComponent<DragTransformClassic>().dragging);
        }
        
        if (check)
        {
            for (int i = 0; i < minigames.Length; i++)
            {
                //minigames[i].GetComponent<DragTransformClassic>().dragging = false;
                minigames[i].transform.position = originalPos[i];
                minigames[i].GetComponent<Renderer>().material.color = originalCol[i];
                //if (minigames[i].GetComponent<DragTransformClassic>() != null) { minigames[i].GetComponent<DragTransformClassic>().dragging = false; }
            }
            transform.parent.gameObject.GetComponent<MalfunctionController>().OffMinigame(originalColor, gameObject);
        }
    }
}
