using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalfunctionController : MonoBehaviour
{
    public float timerReset = 10;
    public float timer;
    public int lastSeconds;
    public GameObject minigame;
    public float[] rates = {0.75f, 0.5f, 0.25f, 0.05f};
    public float boost = 0;
    public float malfunctionChance = 0.75f;
    public bool isMalfunctioning = false;
    private Color redFlash = Color.red;
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
        redFlash.r = 1.0f;
        redFlash.g = 0.25f*UnityEngine.Mathf.Sin(8*timer)+0.25f;
        redFlash.b = redFlash.g;

        if (seconds != lastSeconds)
        {
            if(boost > 0)
            {
                boost -= 0.01f;
            }
            if (minigame.activeSelf)
            {
                GameObject.FindWithTag("Stats").GetComponent<ScoreController>().health -= 1;
            }
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
            malfunctionChance = rates[supportsConnected]-boost;

            float outcome = UnityEngine.Random.value;
            Debug.Log(room.title+" has "+outcome + " needing to beat " + malfunctionChance);

            if(outcome < malfunctionChance)
            {
                minigame.SetActive(true);
                isMalfunctioning = true;
            }
            else
            {
                isMalfunctioning = false;
            }
            timer = timerReset;
        }
        lastSeconds = seconds;
    }

    public void OffMinigame(Color originalColor, GameObject g)
    {
        ChangeColor(originalColor, gameObject);
        Camera.main.GetComponent<Camera>().backgroundColor = Color.black;
        gameObject.GetComponent<MalfunctionController>().isMalfunctioning = false;
        g.gameObject.SetActive(false);
    }
    
    public void ChangeColor(Color c, GameObject g)
    {
        Color toUse;
        if (c == Color.red)
        {
            redFlash.r = 1.0f;
            toUse = redFlash;
        }
        else
        {
            toUse = c;
        }
        foreach (Transform child in g.transform)
        {
            if (child.tag == "Room")
            {
                child.GetComponent<Renderer>().material.color = toUse;
            }
            if (child.tag == "Image")
            {
                child.GetComponent<Renderer>().material.color = toUse;
            }

        }
    }
}
