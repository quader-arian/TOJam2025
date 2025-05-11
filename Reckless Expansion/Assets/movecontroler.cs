using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecontroler : MonoBehaviour
{
    public GameObject left;
    public GameObject right;
    public int swipeCount;

    // Update is called once per frame
    void Update()
    {
        if (left.GetComponent<Movecontrol>().mousedOver && right.GetComponent<Movecontrol>().mousedOver)
        {
            swipeCount++;
            left.GetComponent<Movecontrol>().mousedOver = false;
            right.GetComponent<Movecontrol>().mousedOver = false;
            Debug.Log("Swiped"+swipeCount);
        }
    }
}
