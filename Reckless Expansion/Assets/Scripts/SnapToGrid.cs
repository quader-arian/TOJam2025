using UnityEngine;

public class SnapToGrid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var curr = transform.position;
        transform.position = new Vector3(Mathf.Round(curr.x), Mathf.Round(curr.y), Mathf.Round(curr.z));
    }
}
