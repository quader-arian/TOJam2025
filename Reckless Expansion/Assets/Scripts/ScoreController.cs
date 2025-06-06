using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{

    public float score;
    public float money;
    public float health = 100;
    public float tokens;
    public int rooms;
    public float timer = 0;
    public TMP_Text tmpt;
    public int lastSeconds = 0;
    private bool adding = false;

    // Start is called before the first frame update
    void Start()
    {
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
            int scoreGain = 0;
            int moneyGain = 0;
            foreach (GameObject p in GameObject.FindGameObjectsWithTag("Place"))
            {
                scoreGain += (int)(p.GetComponent<RoomStats>().popGain*0.5);
                moneyGain += (int)(p.GetComponent<RoomStats>().currencyGain*0.5);
            }
            score += scoreGain;
            money += moneyGain;
            lastSeconds = seconds;
        }

        if (seconds % 30 == 0 && adding)
        {
            tokens += 2;
            adding = false;
        }
        if (seconds % 30 == 1)
        {
            adding = true;
        }

        bool malfunctioning = false;
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Place"))
        {
            if (g.GetComponent<MalfunctionController>().isMalfunctioning)
            {
                malfunctioning = true;
                break;
            }
        }
        ToggleAllPlaceHitboxes(!malfunctioning);

        tmpt.text = "Time: " + timerString + "\nScore: " + score + "\nStellar Marks: $" + money + "\nLife Support Tokens: �" + tokens + "\nRooms: " + rooms + "\nHealth: " + health;
    }

    void ToggleAllPlaceHitboxes(bool toggle)
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Place"))
        {
            g.GetComponent<BoxCollider2D>().enabled = toggle;
        }
    }
}
