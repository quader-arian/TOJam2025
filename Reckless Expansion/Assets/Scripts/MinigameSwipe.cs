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
    private Color originalColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.parent.gameObject.GetComponent<MalfunctionController>().ChangeColor(Color.red, transform.parent.gameObject);
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
            hits = 0;
            transform.parent.gameObject.GetComponent<MalfunctionController>().OffMinigame(originalColor, gameObject);
        }
    }
}
