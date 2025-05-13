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
    public float[] rates = {0.75f, 0.5f, 0.25f, 0.05f};
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
        }

        if (timer < 0 )
        {
            RoomStats mal = GetComponent<RoomStats>();
            int malfunctionCheck = 0;

            if (mal.isNutrientsConnected)
            {
                malfunctionCheck++;
            }if (mal.isOxygenConnected)
            {
                malfunctionCheck++;
            }if (mal.isWaterConnected)
            {
                malfunctionCheck++;
            }
            Debug.Log("Support Connects: " + malfunctionCheck);

            float malfunctionChance = rates[0];
            if (malfunctionCheck == 1)
            {
                malfunctionChance = rates[1];
            }else if (malfunctionCheck == 2)
            {
                malfunctionChance = rates[2];
            }
            else if (malfunctionCheck == 3)
            {
                malfunctionChance = rates[3];
            }

            float outcome = Random.value;
            Debug.Log(mal.title+" has "+outcome + " needing to beat " + malfunctionChance);
            if(outcome < malfunctionChance)
            {
                minigame.SetActive(true);
            }
            timer = timerReset;
        }
        lastSeconds = seconds;
    }
}
