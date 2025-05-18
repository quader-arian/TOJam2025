using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameClick : MonoBehaviour
{
    public GameObject[] minigames;
    public int hits;
    private Color[] originalCol;
    private Color originalColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        originalCol = new Color[minigames.Length];
        for (int i = 0; i < minigames.Length; i++)
        {
            originalCol[i] = minigames[i].GetComponent<Renderer>().material.color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.parent.gameObject.GetComponent<MalfunctionController>().ChangeColor(Color.red, transform.parent.gameObject);
        Camera.main.GetComponent<Camera>().backgroundColor = Color.red;

        bool check = true;
        foreach (GameObject m in minigames)
        {
            if(m.activeSelf)
            {
                check = false;
                break;
            }
        }
        //Debug.Log(check);
        if (check)
        {
            for (int i = 0; i < minigames.Length; i++)
            {
                minigames[i].SetActive(true);
                minigames[i].GetComponent<Renderer>().material.color = originalCol[i];
            }
            transform.parent.gameObject.GetComponent<MalfunctionController>().OffMinigame(originalColor, gameObject);
        }
    }

    
}
