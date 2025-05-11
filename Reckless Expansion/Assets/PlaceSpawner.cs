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

        var build1 = Instantiate(rooms[Random.Range(0, rooms.Length)], spawners[0].transform.position, spawners[0].transform.rotation);
        build1.transform.parent = this.transform;
        var build2 = Instantiate(rooms[Random.Range(0, rooms.Length)], spawners[1].transform.position, spawners[1].transform.rotation);
        build2.transform.parent = this.transform;  
        var build3 = Instantiate(rooms[Random.Range(0, rooms.Length)], spawners[2].transform.position, spawners[2].transform.rotation);
        build3.transform.parent = this.transform;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
