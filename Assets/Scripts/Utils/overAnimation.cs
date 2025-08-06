using UnityEngine;

public class overAnimation : MonoBehaviour
{
    public Sprite spriteWithoutHover;
    public Sprite spriteOnHover;

    private SpriteRenderer mySprite;

    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
    }

    void OnMouseOver()
    {
        mySprite.sprite = spriteOnHover;
    }

    void OnMouseExit()
    {
        mySprite.sprite = spriteWithoutHover;
    }

}
