using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public Color mouseOverColor = Color.blue;
    private Color originalColor;

    private void Start()
    {
        originalColor = GetComponentInChildren<Renderer>().material.color;
    }

    void OnMouseEnter()
    {
        if (!this.enabled) return;
        GetComponent<Renderer>().material.color = mouseOverColor;
    }

    void OnMouseExit()
    {
        if (!this.enabled) return;
        GetComponent<Renderer>().material.color = originalColor;
    }

}
