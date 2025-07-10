using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PersonSpawner : MonoBehaviour
{
    public GameObject target;
    public GameObject prefab;
    public float timer = 5;
    public float minReset = 3;
    public float maxReset = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = Random.Range(minReset, maxReset);
            prefab.GetComponent<Movement>().bounds = gameObject.GetComponent<SpriteRenderer>().bounds;
            GameObject instance = Instantiate(prefab, target.transform.position, target.transform.rotation);
            instance.transform.parent = transform;
        }
    }
}
