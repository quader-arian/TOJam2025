using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnColor : MonoBehaviour
{
    public Color[] colors;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = colors[Random.Range(0,colors.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
