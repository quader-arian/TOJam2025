using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ObjectChangeEventStream;

public class PlaceSpawner : MonoBehaviour
{
    public GameObject[] rooms;
    public GameObject[] spawners;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] builds = new GameObject[3];
        for(int i = 0; i < builds.Length; i++)
        {
            builds[i] = Instantiate(rooms[Random.Range(0, rooms.Length)], spawners[i].transform.position, spawners[i].transform.rotation);
            builds[i].GetComponent<DragTransform>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
