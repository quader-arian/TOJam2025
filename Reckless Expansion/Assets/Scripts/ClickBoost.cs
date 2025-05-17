using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBoost : MonoBehaviour
{
    private ScoreController controller;
    public Color mouseOverColor = Color.green;
    private Color originalColor = Color.white;
    public int type = 0;

    private void Start()
    {
        controller = GameObject.FindWithTag("Stats").GetComponent<ScoreController>();
    }
    private void OnMouseUp()
    {
        if (!this.enabled) return; 
        else {
            controller = GameObject.FindWithTag("Stats").GetComponent<ScoreController>();
        }
        foreach (Transform child in transform)
        {
            if (child.tag == "Room")
            {
                child.GetComponent<Renderer>().material.color = originalColor;
            }
            if (child.tag == "Image")
            {
                child.GetComponent<Renderer>().material.color = originalColor;
            }
        }

        if (type == 0)
        {
            controller.score++;
            controller.money++;
        }
        else if (type == 1)
        {
            foreach(GameObject child in GetComponent<RoomStats>().connectedRooms)
            {
                child.GetComponent<MalfunctionController>().boost += 0.01f;
            }
        }
    }
    private void OnMouseDown()
    {
        if (!this.enabled) return;
        foreach (Transform child in transform)
        {
            if (child.tag == "Room")
            {
                child.GetComponent<Renderer>().material.color = mouseOverColor;
            }
            if (child.tag == "Image")
            {
                child.GetComponent<Renderer>().material.color = mouseOverColor;
            }
        }
    }
}
