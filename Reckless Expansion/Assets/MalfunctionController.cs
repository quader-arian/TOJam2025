using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SocialPlatforms.Impl;

public class MalfunctionController : MonoBehaviour
{
    public float timerReset = 10;
    public float timer;
    public int lastSeconds;
    public GameObject minigame;
    // Start is called before the first frame update
    void Start()
    {
        timer = timerReset;
        lastSeconds = (int)timer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        int seconds = Mathf.FloorToInt(timer % 60F);

        if (seconds != lastSeconds && minigame.activeSelf)
        {
            GameObject.FindWithTag("Stats").GetComponent<ScoreController>().health -= 1;
            lastSeconds = seconds;
        }

        if (timer < 0 )
        {
            if(Random.Range(0, 100) < GetComponent<RoomStats>().malfunction)
            {
                minigame.SetActive(true);
            }
            timer = timerReset;
            lastSeconds = seconds;
        }
        
    }
}
