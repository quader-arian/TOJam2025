using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MalfunctionController : MonoBehaviour
{
    public float timerReset = 60;
    public float timer = 60;
    public GameObject minigame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (minigame.activeSelf)
        {

        } 

        if (timer < 0)
        {
            minigame.SetActive(true);
            timer = timerReset;
        }
        
    }
}
