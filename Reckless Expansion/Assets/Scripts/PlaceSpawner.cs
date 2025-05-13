using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine.UI;
public class PlaceSpawner : MonoBehaviour
{
    public GameObject[] rooms;
    public GameObject[] spawners;
    public GameObject[] buyButtons;
    public GameObject moneyStats;
    public int type = 0;
    GameObject[] builds = new GameObject[3];
    int bought = -1;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < builds.Length; i++)
        {
            spawnRoom(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (type == 0) { 
            float money = moneyStats.GetComponent<ScoreController>().money; 
        }
        else
        {
            float money = moneyStats.GetComponent<ScoreController>().tokens;
        }

        if (bought >= 0)
        {
            if (!builds[bought].GetComponent<DragTransform>().enabled)
            {
                buyButtons[bought].GetComponent<Button>().interactable = true;
                builds[bought] = null;
                spawnRoom(bought);
                bought = -1;
            }
        }
    }

    public void attemptBuy(int i)
    {
        bool check = false;
        if (type == 0)
        {
            check = builds[i].GetComponent<RoomStats>().cost <= moneyStats.GetComponent<ScoreController>().money;
        }
        else
        {
            check = builds[i].GetComponent<RoomStats>().cost <= moneyStats.GetComponent<ScoreController>().tokens;
        }

        if (check)
        {
            buyButtons[i].GetComponent<Button>().interactable = false;
            if(type == 0)
            {
                moneyStats.GetComponent<ScoreController>().money -= builds[i].GetComponent<RoomStats>().cost;
            }
            else
            {
                moneyStats.GetComponent<ScoreController>().tokens -= builds[i].GetComponent<RoomStats>().cost;
            }
            builds[i].GetComponent<DragTransform>().enabled = true;
            builds[i].GetComponent<MalfunctionController>().enabled = true;
            builds[i].tag = "Place";
            foreach (Transform child in builds[i].transform)
            {
                if (child.tag == "Up" || child.tag == "Down" || child.tag == "Left" || child.tag == "Right")
                {
                    child.GetComponent<Connection>().enabled = true;
                }
            }
            builds[i].transform.parent = null;
            bought = i;
        }
    }

    void spawnRoom(int i)
    {
        if(type == 0)
        {
            builds[i] = Instantiate(rooms[Random.Range(0, rooms.Length)], spawners[i].transform.position, spawners[i].transform.rotation);
        }
        else
        {
            builds[i] = Instantiate(rooms[i], spawners[i].transform.position, spawners[i].transform.rotation);
        }
        builds[i].transform.parent = this.gameObject.transform;
        builds[i].tag = "Untagged";
        builds[i].GetComponent<DragTransform>().enabled = false;
        builds[i].GetComponent<MalfunctionController>().enabled = false;
        foreach (Transform child in builds[i].transform)
        {
            if (child.tag == "Up" || child.tag == "Down" || child.tag == "Left" || child.tag == "Right")
            {
                child.GetComponent<Connection>().enabled = false;
            }
        }
        buyButtons[i].transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = builds[i].GetComponent<RoomStats>().title + "\n$" + builds[i].GetComponent<RoomStats>().cost;
    }
}
