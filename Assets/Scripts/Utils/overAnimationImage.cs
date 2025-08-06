using UnityEngine;
using UnityEngine.UI;


public class overAnimationImage : MonoBehaviour
{
    public Sprite spriteWithoutHover;
    public Sprite spriteOnHover;

    private Image myImage;
    private RectTransform rt;

    void Start()
    {
        rt = GetComponent<RectTransform>();
        myImage = GetComponent<Image>();
    }

    void OnMouseOver()
    {
        rt.sizeDelta = new Vector2(51, rt.sizeDelta.y);
        myImage.sprite = spriteOnHover;
    }

    void OnMouseExit()
    {
        rt.sizeDelta = new Vector2(35, rt.sizeDelta.y);
        myImage.sprite = spriteWithoutHover;
    }

}
