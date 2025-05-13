using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Connection : MonoBehaviour
{
    private Color successColor = Color.blue;
    private Color originalColor;
    private bool locked = false;

    private void Start()
    {
        originalColor = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LockCheck(bool lockIt)
    {
        GameObject[] connects = null;
        if (tag == "Up")
        {
            connects = GameObject.FindGameObjectsWithTag("Down");
        }
        else if (tag == "Left")
        {
            connects = GameObject.FindGameObjectsWithTag("Right");
        }
        else if (tag == "Right")
        {
            connects = GameObject.FindGameObjectsWithTag("Left");
        }
        else if (tag == "Down")
        {
            connects = GameObject.FindGameObjectsWithTag("Up");
        }

        GameObject[] rooms = null;
        rooms = GameObject.FindGameObjectsWithTag("Room");
        bool pipesConnected = false;
        List<GameObject> potentialLinks = new List<GameObject>();

        foreach (GameObject c in connects)
        {
            if (this.transform.position == c.transform.position)
            {
                potentialLinks.Add(this.gameObject);
                GetComponent<Renderer>().material.color = successColor;
                potentialLinks.Add(c);
                c.GetComponent<Renderer>().material.color = successColor;
                pipesConnected = true;
            }
            else
            {
                if (!potentialLinks.Contains(this.gameObject))
                {
                    GetComponent<Renderer>().material.color = originalColor;
                }
                if (!potentialLinks.Contains(this.gameObject) && !c.GetComponent<Connection>().locked)
                {
                    c.GetComponent<Renderer>().material.color = originalColor;
                }
            }
        }

        bool interesectFound = false;
        for (int i = 0; pipesConnected && i < rooms.Length - 1; i++)
        {
            for (int j = i + 1; j < rooms.Length; j++)
            {
                //Debug.Log(rooms[i].transform.position + " " + rooms[j].transform.position);
                if (rooms[i].transform.position == rooms[j].transform.position)
                {
                    interesectFound = true;
                    break;
                }
            }
        }

        if (!interesectFound && pipesConnected)
        {
            GetComponentInParent<DragTransform>().ResetColor();
            if (lockIt)
            {
                foreach (GameObject p in potentialLinks)
                {
                    p.GetComponent<Connection>().locked = true;
                    checkAttachedSupport(p);
                }
                GetComponentInParent<DragTransform>().enabled = false;
            }
        }
    }
    
    void checkAttachedSupport(GameObject g)
    {
        RoomStats other = g.transform.parent.gameObject.GetComponent<RoomStats>();
        RoomStats current = transform.parent.gameObject.GetComponent<RoomStats>();
        updateSupportStats(current, other);
        updateSupportStats(other, current);
    }

    void updateSupportStats(RoomStats current, RoomStats other)
    {
        if (other.isNutrients)
        {
            current.isNutrientsConnected = true;
            Debug.Log("Nutrients Connected");
        }
        else if (other.isOxygen)
        {
            current.isOxygenConnected = true;
            Debug.Log("Oxygen Connected");
        }
        else if (other.isWater)
        {
            current.isWaterConnected = true;
            Debug.Log("Water Connected");
        }
    }
}
