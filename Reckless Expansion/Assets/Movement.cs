using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float step = 2f;
    public float timer = 5;
    public float minReset = 3;
    public float maxReset = 5;
    private Vector2 target;
    private Vector2 position;
    public Bounds bounds;

    // Start is called before the first frame update
    void Start()
    {
        target = new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));
        position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, step);
        if (timer <= 0)
        {
            timer = Random.Range(minReset, maxReset);
            target = new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));
        }
    }
}
