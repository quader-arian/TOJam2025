using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{

    public float score;
    public float money;
    public float health;
    public float tokens;
    public int rooms;
    public float timer = 0;
    public TMP_Text tmpt;
    public int lastSeconds = 0;
    public int roomSubtract = 0;
    public bool adding = false;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        tokens = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer % 60F);
        int hours = (int)(timer / 3600);

        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        rooms = GameObject.FindGameObjectsWithTag("Place").Length;
        if(seconds != lastSeconds)
        {
            score += rooms * 10;
            money += rooms * 5;
            lastSeconds = seconds;
        }

        if (seconds % 10 == 0 && adding)
        {
            tokens += 5;
            adding = false;
        }
        if (seconds % 10 == 1)
        {
            adding = true;
        }

        tmpt.text = "Time: " + timerString + "\nScore: " + score + "\nStellar Marks: $" + money + "\nLife support tokens: " + tokens + "\nRooms: " + (rooms-roomSubtract) + "\nHealth: " + health;
    }
}
