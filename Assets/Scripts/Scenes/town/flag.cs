using UnityEngine;
using System.Collections;
using System.Collections.Specialized;

public class flag : MonoBehaviour
{
    public Sprite[] sprites;
    public int maxSprites = 0;

    private SpriteRenderer mySpriteRenderer;
    private int index = 0;

    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkCoRutine());
    }


    IEnumerator WalkCoRutine()
    {
        yield return new WaitForSeconds(0.05f);
        mySpriteRenderer.sprite = sprites[index];
        index++;
        if (index == maxSprites)
        { 
            index = 0;
        }
        StartCoroutine(WalkCoRutine());
    }
}
