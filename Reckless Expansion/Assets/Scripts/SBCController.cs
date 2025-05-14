using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;
using TMPro;

public class SBCController : MonoBehaviour
{
    public float timerReset = 60;
    public float timer = 60;
    public int missionType = 0;
    public int target = 10;
    public int healthLoss = 20;
    public int successes = 0;
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer % 60F);
        int hours = (int)(timer / 3600);

        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (missionType == 0)
        {
            text.text = "SBC MISSION: GET " + target + " ROOMS IN " + timerString;
        }
        else if (missionType == 1)
        {
            text.text = "SBC MISSION: REACH " + target + " SCORE IN " + timerString;
        }
        else if (missionType == 2)
        {
            text.text = "SBC MISSION: HAVE $" + target + " BY " + timerString;
        }

        if (timer <= 0)
        {
            timer = timerReset;
            int currentStat;
            ScoreController stats = GameObject.FindWithTag("Stats").GetComponent<ScoreController>();
            if (missionType == 0)
            {
                currentStat = stats.rooms;
            }else if(missionType == 1)
            {
                currentStat = (int)stats.score;
            }else
            {
                currentStat = (int)stats.money;
            }

            if (currentStat < target)
            {
                stats.health -= healthLoss;
            }
            else
            {
                successes += 1;
                missionType = Random.Range(0, 3);
                if (missionType == 0)
                {
                    target = stats.rooms + (int)(stats.rooms * (0.5 + (0.1 * successes)));
                }
                else if (missionType == 1)
                {
                    target = (int)(stats.score) + (int)(stats.score * 0.1);
                }
                else
                {
                    target = (int)(stats.money) + (int)(stats.money * 0.1);
                }
            }  
        }
    }
}
