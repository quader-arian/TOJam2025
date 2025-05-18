using UnityEngine;

public class PipeSpriteController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] sprites;

    public void SwapSprite(bool valid)
    {
        sprites[0].SetActive(!valid);
        if(sprites.Length > 1)
        {
            sprites[1].SetActive(valid);
        }
    }
}
