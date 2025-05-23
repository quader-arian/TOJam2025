using System.Collections;
using UnityEngine;

class DragTransformClassic : MonoBehaviour
{
    public Color mouseOverColor = Color.blue;
    private Color originalColor;
    public bool dragging = false;
    private float distance;
    private Vector3 startDist;

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

    void OnMouseDown()
    {
        if (!this.enabled) return;
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayPoint = ray.GetPoint(distance);
        startDist = transform.position - rayPoint;
    }

    void OnMouseUp()
    {
        if (!this.enabled) return;
        dragging = false;
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
        }
    }
}