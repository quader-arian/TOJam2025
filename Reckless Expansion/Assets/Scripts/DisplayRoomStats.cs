using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayRoomStats : MonoBehaviour
{
    private GameObject display;
    private RoomStats room;

    private void Start()
    {
        display = GameObject.FindWithTag("DisplayStats");
        room = GetComponent<RoomStats>();
    }
    void OnMouseOver()
    {
        if (!GetComponent<DragTransform>().dragging)
        {
            display.GetComponent<DisplayText>().display.SetActive(true);
            display.transform.position = transform.position + new Vector3(1, 1, 0);
            TMP_Text tmpText = display.GetComponent<DisplayText>().text.GetComponent<TMP_Text>();
            tmpText.text = "NAME: " + room.title + "\r\nSCORE GAIN: " + room.popGain * 0.5 + "/SEC\r\n$$$ GAIN: " + room.currencyGain * 0.5 + "/SEC\r\nMALFUNC CHANCE: ";

            int connections = 0;
            string supportsString = "";
            if (room.isWaterConnected)
            {
                connections++;
                supportsString += "W";
            }
            else
            {
                supportsString += "-";
            }
            if (room.isOxygenConnected)
            {
                connections++;
                supportsString += "O";
            }
            else
            {
                supportsString += "-";
            }
            if (room.isNutrientsConnected)
            {
                connections++;
                supportsString += "N";
            }
            else
            {
                supportsString += "-";
            }

            float malfunctionTemp = GetComponent<MalfunctionController>().rates[connections] - GetComponent<MalfunctionController>().boost;
            int malfunction = (int)(malfunctionTemp * 100);
            tmpText.text += malfunction + "%\r\nSUPPORTS CONNECTED: " + supportsString;


            string specialText = "";
            if (room.isWater)
            {
                specialText += "\r\nSPECIAL: Water Support";
            }
            if (room.isOxygen)
            {
                specialText += "\r\nSPECIAL: Oxygen Support";
            }
            if (room.isNutrients)
            {
                specialText += "\r\nSPECIAL: Nutrients Support";
            }
            if (room.additionalInfo != "")
            {
                specialText += "\r\nSPECIAL: " + room.additionalInfo;
            }
            tmpText.text += specialText;
        }
    }
    void OnMouseExit()
    {
        display.GetComponent<DisplayText>().display.SetActive(false);
    }
}
