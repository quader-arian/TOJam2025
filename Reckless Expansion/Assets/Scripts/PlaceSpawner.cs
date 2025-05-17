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
    public GameObject button;
    public int type = 0;
    private GameObject[] builds = new GameObject[3];
    int bought = -1;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < builds.Length; i++)
        {
            SpawnRoom(i);
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
            if (builds[bought].GetComponent<DragTransform>().touches == 1)
            {
                gameObject.SetActive(false);
                button.SetActive(true);
                builds[bought].GetComponent<DragTransform>().touches ++;
            }
            if (!builds[bought].GetComponent<DragTransform>().enabled)
            {
                buyButtons[bought].GetComponent<Button>().interactable = true;
                builds[bought] = null;
                SpawnRoom(bought);
                bought = -1;
            }
        }
    }

    public void AttemptBuy(int i)
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
            builds[i].tag = "Place";
            foreach (Transform child in builds[i].transform)
            {
                if (child.tag == "Up" || child.tag == "Down" || child.tag == "Left" || child.tag == "Right")
                {
                    child.GetComponent<Connection>().enabled = true;
                }
            }
            builds[i].transform.parent = null;
            SpecialBoost(builds[i]);
            bought = i;
        }
    }

    void SpawnRoom(int i)
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

        string currency = "\n$";
        if (type == 1) { currency = "\n¥"; }

        buyButtons[i].transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = builds[i].GetComponent<RoomStats>().title + currency + builds[i].GetComponent<RoomStats>().cost;
    }

    void SpecialBoost(GameObject g)
    {
        ScoreController stats = GameObject.FindGameObjectWithTag("Stats").GetComponent<ScoreController>();
        string boostType = g.GetComponent<RoomStats>().additionalInfo;
        if (boostType == "Fixes All Malfunctions")
        {
            foreach (GameObject child in GameObject.FindGameObjectsWithTag("Place"))
            {
                child.GetComponent<MalfunctionController>().minigame.SetActive(false);
            }
        }else if(boostType == "Recover Currency")
        {
            stats.money += (int)(stats.money * g.GetComponent<RoomStats>().boost);
        }else if (boostType == "Recover Health")
        {
            stats.health += (int)g.GetComponent<RoomStats>().boost;
        }else if(boostType == "Malfunction Fixes + $$ + HP")
        {
            foreach (GameObject child in GameObject.FindGameObjectsWithTag("Place"))
            {
                child.GetComponent<MalfunctionController>().minigame.SetActive(false);
            }
            stats.money += (int)(stats.money * g.GetComponent<RoomStats>().boost);
            stats.health += (int)(stats.health * g.GetComponent<RoomStats>().boost);
        }
    }
}
