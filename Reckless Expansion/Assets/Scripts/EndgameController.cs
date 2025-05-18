using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndgameController : MonoBehaviour
{
    public GameObject text;
    public GameObject text1;
    private bool shown = false;
    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Stats").GetComponent<ScoreController>().health <= 0)
        {
            text.SetActive(true);
            if (!shown)
            {
                text1.GetComponent<TMP_Text>().text = "FINAL SCORE: " + GameObject.FindWithTag("Stats").GetComponent<ScoreController>().score;
                shown = true;
                StartCoroutine(DelayAction(6f));
            }
        }
    }

    IEnumerator DelayAction(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Debug.Log("Ending Game");
        SceneManager.LoadScene("MainMenu");
    }
}
