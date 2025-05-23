using System.Collections.Generic;
using UnityEngine;

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
                GetComponent<PipeSpriteController>().SwapSprite(true);
                potentialLinks.Add(c);
                c.GetComponent<Renderer>().material.color = successColor;
                c.GetComponent<PipeSpriteController>().SwapSprite(true);
                pipesConnected = true;
            }
            else
            {
                if (!potentialLinks.Contains(this.gameObject))
                {
                    GetComponent<Renderer>().material.color = originalColor;
                    GetComponent<PipeSpriteController>().SwapSprite(false);
                }
                if (!potentialLinks.Contains(this.gameObject) && !c.GetComponent<Connection>().locked)
                {
                    c.GetComponent<Renderer>().material.color = originalColor;
                    c.GetComponent<PipeSpriteController>().SwapSprite(false);
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
                    p.GetComponent<Renderer>().enabled = false;
                    CheckAttachedRooms(p);
                }
                transform.parent.GetComponent<MalfunctionController>().enabled = true;
                transform.parent.GetComponent<ClickBoost>().enabled = true;
                GetComponentInParent<DragTransform>().enabled = false;
            }
        }
    }
    
    void CheckAttachedRooms(GameObject g)
    {
        GameObject other = g.transform.parent.gameObject;
        GameObject current = transform.parent.gameObject;
        UpdateSupportStats(current, other);
        UpdateSupportStats(other, current);
        UpdateConnectedRooms(current, other);
    }

    void UpdateSupportStats(GameObject current, GameObject other)
    {
        if (other.GetComponent<RoomStats>().isNutrients)
        {
            current.GetComponent<RoomStats>().isNutrientsConnected = true;
            Debug.Log("Nutrients Connected");
        }
        else if (other.GetComponent<RoomStats>().isOxygen)
        {
            current.GetComponent<RoomStats>().isOxygenConnected = true;
            Debug.Log("Oxygen Connected");
        }
        else if (other.GetComponent<RoomStats>().isWater)
        {
            current.GetComponent<RoomStats>().isWaterConnected = true;
            Debug.Log("Water Connected");
        }
    }

    void UpdateConnectedRooms(GameObject current, GameObject other)
    {
        current.GetComponent<RoomStats>().connectedRooms.Add(other);
        other.GetComponent<RoomStats>().connectedRooms.Add(current);
    }
}
