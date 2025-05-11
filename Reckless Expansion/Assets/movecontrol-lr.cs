using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecontrollr : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject left;
    public GameObject right;
    public int swipeCount;
    public bool rightOpen = false;
    public bool rightFirst = false;

    // Update is called once per frame
    void Update()
    {
        if (left.GetComponent<Movecontrol>().mousedOver == true && right.GetComponent<Movecontrol>().mousedOver == false)
        {
            rightOpen = true;
        }
        if (left.GetComponent<Movecontrol>().mousedOver == false && right.GetComponent<Movecontrol>().mousedOver == true)
        {
            rightFirst = true;
        }
        if (left.GetComponent<Movecontrol>().mousedOver && right.GetComponent<Movecontrol>().mousedOver && rightOpen==false && rightFirst)
        {
            left.GetComponent<Movecontrol>().mousedOver = false;
            right.GetComponent<Movecontrol>().mousedOver = false;
            rightFirst = false;
        }
        if (left.GetComponent<Movecontrol>().mousedOver && right.GetComponent<Movecontrol>().mousedOver && rightOpen)
        {
            swipeCount++;
            left.GetComponent<Movecontrol>().mousedOver = false;
            right.GetComponent<Movecontrol>().mousedOver = false;
            Debug.Log("Swiped" + swipeCount);
        }
    }
}
