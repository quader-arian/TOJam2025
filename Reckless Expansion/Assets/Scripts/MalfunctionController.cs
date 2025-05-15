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
            RoomStats room = GetComponent<RoomStats>();
            int supportsConnected = 0;

            if (room.isNutrientsConnected)
            {
                supportsConnected++;
            }if (room.isOxygenConnected)
            {
                supportsConnected++;
            }if (room.isWaterConnected)
            {
                supportsConnected++;
            }
            Debug.Log("Support Connects: " + supportsConnected);

            float malfunctionChance = rates[supportsConnected];

            float outcome = Random.value;
            Debug.Log(room.title+" has "+outcome + " needing to beat " + malfunctionChance);
            if(outcome < malfunctionChance)
            {
                minigame.SetActive(true);
            }
            timer = timerReset;
        }
        lastSeconds = seconds;
    }
}
