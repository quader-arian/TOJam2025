using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransform : MonoBehaviour
{
    bool dragging;
    Vector3 dragCamInitialPos;
    Vector3 dragMouseInitialPos;
    public float sensitivity = 1;

    void Start()
    {
        dragging = false;
    }

    void Update()
    {
        var moveButton = Input.GetKey(KeyCode.Mouse1);
        if (!dragging)
        {
            if (moveButton)
            {
                dragCamInitialPos = transform.position;
                dragMouseInitialPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                dragging = true;
            }
        }
        else
        {
            if (moveButton)
            {
                var mouse = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                var delta = mouse - dragMouseInitialPos;
                delta.x *= Camera.main.aspect * Camera.main.orthographicSize / 0.5f;
                delta.y *= Camera.main.orthographicSize / 0.5f;
                transform.position = dragCamInitialPos - delta;
            }
            else
            {
                dragging = false;
            }
        }

        int zoom = (int)(Camera.main.orthographicSize - (Input.mouseScrollDelta.y * sensitivity));
        if (zoom >= 1  && zoom <= 30)
        {
            Camera.main.orthographicSize =zoom;
        }
    }
}
