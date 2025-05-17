using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int cost = 0;
    public int popGain = 0;
    public int currencyGain = 0;
    public int type = 0;
    public string additionalInfo = " ";
    public float boost = 0;
    public bool isWater = false;
    public bool isNutrients = false;
    public bool isOxygen = false;
    public bool isWaterConnected = false;
    public bool isNutrientsConnected = false;
    public bool isOxygenConnected = false;
    public string title = "";
    public HashSet<GameObject> connectedRooms = new HashSet<GameObject>();

    // Update is called once per frame
    void Update()
    {
    }
}
