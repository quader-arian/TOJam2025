using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MinigameClick : MonoBehaviour
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

        bool check = true;
        foreach (GameObject m in minigames)
        {
            if(m.activeSelf)
            {
                check = false;
                break;
            }
        }
        //Debug.Log(check);
        if (check)
        {
            foreach (GameObject m in minigames)
            {
                m.SetActive(true);
            }
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
