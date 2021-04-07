using UnityEngine;
using UnityEngine.UI;

public class MyButton : MonoBehaviour
{
    public Sprite[] buttonSprites;
    private Image img;

    void Start()
    {
        img = GetComponent<Image>();
    }

    public void ButtonUp()
    {
        img.sprite = buttonSprites[0];
    }

    public void ButtonDown()
    {
        img.sprite = buttonSprites[1];
    }
}
