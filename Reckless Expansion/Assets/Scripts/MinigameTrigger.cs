using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameTrigger : MonoBehaviour
{
    public bool entered = false;
    private void OnMouseEnter()
    {
        entered = true;
    }

    private void OnMouseExit()
    {
        entered = true;
    }
}
