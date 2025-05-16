using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MinigameDrag : MonoBehaviour
{
    public GameObject[] minigames;
    public int hits;
    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        originalColor = GetComponentInChildren<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColor(Color.red);
        Camera.main.GetComponent<Camera>().backgroundColor = Color.red;

        //Debug.Log(check);
        bool check = true;
        for (int i = 0; i < minigames.Length; i=i+2)
        {
            check = check && (minigames[i].transform.position == minigames[i + 1].transform.position);
        }

        if (check)
        {
            ChangeColor(originalColor);
            Camera.main.GetComponent<Camera>().backgroundColor = Color.black;
            this.gameObject.SetActive(false);
        }
    }

    void ChangeColor(Color c)
    {
        foreach (Transform child in transform.parent)
        {
            if (child.tag == "Room")
            {
                child.GetComponent<Renderer>().material.color = c;
            }
            
        }
    }
}
