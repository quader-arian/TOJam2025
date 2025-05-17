using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class MinigameSwipe : MonoBehaviour
{
    private int hits;
    public int maxHits;
    public TMP_Text display;
    public string message = "SWIPE LEFT TO RIGHT:";
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

        bool check = true;
        foreach (Transform child in transform)
        {
            if(child.GetComponent<MinigameTrigger>() != null)
            {
                check = check && child.GetComponent<MinigameTrigger>().entered;
            }
        }
        //Debug.Log(check);
        if (check)
        {
            hits++;
            foreach (Transform child in transform)
            {
                if (child.GetComponent<MinigameTrigger>() != null)
                {
                    child.GetComponent<MinigameTrigger>().entered = false;

                }
            }
        }

        display.text = message+ " " + (maxHits - hits);
        if (hits >= maxHits)
        {
            ChangeColor(originalColor);
            Camera.main.GetComponent<Camera>().backgroundColor = Color.black;
            hits = 0;
            GameObject.FindWithTag("Stats").GetComponent<ScoreController>().malfunctions -= 1;
            transform.parent.GetComponent<MalfunctionController>().isMalfunctioning  = false;
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
