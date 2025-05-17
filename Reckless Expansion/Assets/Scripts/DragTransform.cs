using System.Collections;
using UnityEngine;

class DragTransform : MonoBehaviour
{
    public Color mouseOverColor = Color.blue;
    private Color originalColor = Color.white;
    public bool dragging = false;
    private float distance;
    private Vector3 startDist;
    public int touches = 0;

    private void Start()
    {
    }

    void OnMouseEnter()
    {
        if (!this.enabled) return;
        foreach (Transform child in transform)
        {
            if(child.tag == "Room")
            {
                child.GetComponent<Renderer>().material.color = mouseOverColor;
            }
            if (child.tag == "Image")
            {
                child.GetComponent<Renderer>().material.color = mouseOverColor;
            }
        }
    }

    void OnMouseExit()
    {
        if (!this.enabled) return;
        ResetColor();
    }
    public void ResetColor()
    {
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
    }

    void OnMouseDown()
    {
        if (!this.enabled) return;
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayPoint = ray.GetPoint(distance);
        startDist = transform.position - rayPoint;
        touches++;
    }

    void OnMouseUp()
    {
        if (!this.enabled) return;
        dragging = false;
        foreach (Transform child in transform)
        {
            if(child.GetComponent<Connection>() != null)
            {
                child.GetComponent<Connection>().LockCheck(true);

            }
        }
    }

    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint + startDist;
            var curr = transform.position;
            transform.position = new Vector3(Mathf.Round(curr.x), Mathf.Round(curr.y), Mathf.Round(curr.z));

            foreach (Transform child in transform)
            {
                if (child.GetComponent<Connection>() != null)
                {
                    child.GetComponent<Connection>().LockCheck(false);

                }
            }
        }
    }
}