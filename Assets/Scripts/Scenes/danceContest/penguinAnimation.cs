using System.Collections;
using UnityEngine;

public class penguinAnimation : MonoBehaviour
{
    private Sprite[] currentSprites;
    public string path;
    public int maxSprites = 0;
    public float time;

    private SpriteRenderer mySpriteRenderer;

    void Start()
    {
        currentSprites = Resources.LoadAll<Sprite>(path);
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkCoRutine());
    }


    IEnumerator WalkCoRutine()
    {
        foreach(Sprite frame in currentSprites)
        {
            yield return new WaitForSeconds(time);
            mySpriteRenderer.sprite = frame;
        }
        StartCoroutine(WalkCoRutine());
    }
}
