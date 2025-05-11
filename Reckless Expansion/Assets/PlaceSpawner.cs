using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaceSpawner : MonoBehaviour
{
    public GameObject[] rooms;
    public GameObject[] spawners;
    public GameObject[] buyButtons;
    public GameObject moneyStats;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] builds = new GameObject[3];
        for(int i = 0; i < builds.Length; i++)
        {
            builds[i] = Instantiate(rooms[Random.Range(0, rooms.Length)], spawners[i].transform.position, spawners[i].transform.rotation);
            builds[i].transform.parent = this.gameObject.transform;
            builds[i].GetComponent<DragTransform>().enabled = false;
            buyButtons[i].transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = builds[i].name + ": $" + builds[i].GetComponent<RoomStats>().cost;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float money = moneyStats.GetComponent<ScoreController>().money;
        //builds[i];
    }
}
