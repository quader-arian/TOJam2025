using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MinigameClick : MonoBehaviour
{
    public GameObject[] minigames;
    public int hits;
    private Color originalColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {
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
            foreach (GameObject m in minigames)
            {
                m.SetActive(true);
            }
            transform.parent.gameObject.GetComponent<MalfunctionController>().OffMinigame(originalColor, gameObject);
        }
    }

    
}
