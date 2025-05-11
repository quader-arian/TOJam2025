using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine.UI;

public class PlaceSpawner1 : MonoBehaviour
{
    public GameObject[] rooms;
    public GameObject[] spawners;
    public GameObject[] buyButtons;
    public GameObject moneyStats;
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
        float money = moneyStats.GetComponent<ScoreController>().money;
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
        if (builds[i].GetComponent<RoomStats>().cost <= moneyStats.GetComponent<ScoreController>().tokens)
        {
            buyButtons[i].GetComponent<Button>().interactable = false;
            moneyStats.GetComponent<ScoreController>().tokens -= builds[i].GetComponent<RoomStats>().cost;
            builds[i].GetComponent<DragTransform>().enabled = true;
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
        builds[i] = Instantiate(rooms[i], spawners[i].transform.position, spawners[i].transform.rotation);
        builds[i].transform.parent = this.gameObject.transform;
        builds[i].GetComponent<DragTransform>().enabled = false;
        foreach (Transform child in builds[i].transform)
        {
            if (child.tag == "Up" || child.tag == "Down" || child.tag == "Left" || child.tag == "Right")
            {
                child.GetComponent<Connection>().enabled = false;
            }
        }
        buyButtons[i].transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = builds[i].GetComponent<RoomStats>().title + "\n¥" + builds[i].GetComponent<RoomStats>().cost;
    }
}
