using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    public GameObject[] minigames;
    public int hits;
    public int type;
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

        if (type == 0)
        {
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
                foreach (Transform child in transform)
                {
                    if (child.GetComponent<MinigameTrigger>() != null)
                    {
                        child.GetComponent<MinigameTrigger>().entered = false;

                    }
                }
                ChangeColor(originalColor);
                Camera.main.GetComponent<Camera>().backgroundColor = Color.black;
                this.gameObject.SetActive(false);
            }
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
