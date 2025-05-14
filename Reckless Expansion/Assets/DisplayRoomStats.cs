using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayRoomStats : MonoBehaviour
{
    private GameObject display;
    private GameObject stats;

    private void Start()
    {
        display = GameObject.FindWithTag("DisplayStats");
    }
    private void OnMouseOver()
    {
        if (!GetComponent<DragTransform>().dragging)
        {
            display.SetActive(true);
            TMP_Text tmpText = display.GetComponent<DisplayText>().text.GetComponent<TMP_Text>();
            tmpText.text = string.Format("SCORE GAIN: {0}/SEC\r\n$$$ GAIN: {1}/SEC\r\nMALFUNC CHANCE: {2}%\r\nPROVIDES SUPPORT: {3}\r\nSUPPORTS CONNECTED: {4}");
        }
    }
}
