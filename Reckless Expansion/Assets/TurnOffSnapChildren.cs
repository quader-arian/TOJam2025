using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffSnapChildren : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayAction(0.1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DelayAction(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        foreach (Transform child in transform)
        {
            child.GetComponent<SnapToGrid>().enabled = false;
        }
    }
}
