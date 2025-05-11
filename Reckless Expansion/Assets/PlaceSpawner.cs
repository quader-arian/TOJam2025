using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaceSpawner : MonoBehaviour
{
    public GameObject[] rooms;
    public GameObject[] spawners;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(rooms[Random.Range(0, rooms.Length)], spawners[0].transform.position, spawners[0].transform.rotation);
        Instantiate(rooms[Random.Range(0, rooms.Length)], spawners[1].transform.position, spawners[1].transform.rotation);
        Instantiate(rooms[Random.Range(0, rooms.Length)], spawners[2].transform.position, spawners[2].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
