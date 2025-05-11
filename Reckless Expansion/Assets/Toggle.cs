using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] objects;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ToggleOnOff()
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(!obj.activeSelf);
        }
    }

    void OnMouseUp()
    {
        ToggleOnOff();
    }
}
