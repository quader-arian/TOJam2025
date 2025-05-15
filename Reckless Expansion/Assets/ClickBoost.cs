using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBoost : MonoBehaviour
{
    private ScoreController controller;
    public Color mouseOverColor = Color.green;
    private Color originalColor;
    public int type = 0;

    private void Start()
    {
        controller = GameObject.FindWithTag("Stats").GetComponent<ScoreController>();
        originalColor = GetComponentInChildren<Renderer>().material.color;
    }
    private void OnMouseUp()
    {
        if(type == 0)
        {
            controller.score++;
            foreach (Transform child in transform)
            {
                if (child.tag == "Room")
                {
                    child.GetComponent<Renderer>().material.color = originalColor;
                }
            }
        }
    }
    private void OnMouseDown()
    {
        foreach (Transform child in transform)
        {
            if (child.tag == "Room")
            {
                child.GetComponent<Renderer>().material.color = mouseOverColor;
            }
        }
    }
}
