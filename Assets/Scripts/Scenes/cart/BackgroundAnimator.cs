using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Versioning;
using UnityEngine;

public class BackgroundAnimator : MonoBehaviour
{
    private Sprite[] currentSprites;
    private SpriteRenderer spriteRenderer;
    private bool isSpriteRunning = false;

    public float spriteChangeInterval = .5f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        Sprite[] SSPrites = Resources.LoadAll<Sprite>("Backgrounds/Surf/S");
        Sprite[] LRSprites = Resources.LoadAll<Sprite>("Backgrounds/Surf/LR");
        currentSprites = SSPrites.OrderBy(s => int.Parse(System.Text.RegularExpressions.Regex.Match(s.name, @"\d+").Value)).ToArray();

        StartCoroutine(AnimateBackground());
        StartCoroutine(SimulateDirectionChange(SSPrites, LRSprites)); 
    }

    IEnumerator AnimateBackground()
    {
        while (true)
        {
            foreach(Sprite sprite in currentSprites) {

                spriteRenderer.sprite = sprite;
                yield return new WaitForSeconds(0.065f);

            }
            isSpriteRunning = false;
        }

        yield return new WaitForSeconds(.5f);
    }

    IEnumerator SimulateDirectionChange(Sprite[] straight, Sprite[] lr)
    {
        while (true)
        {
            yield return new WaitForSeconds(0.005f);
            if (!isSpriteRunning)
            {
                isSpriteRunning = true;
                int rand = UnityEngine.Random.Range(0, 4);
                switch (rand)
                {

                    case 0:
                        SetSprites(straight, false);
                        break;
                    case 1:
                        SetSprites(straight, false);
                        break;
                    case 2:
                        SetSprites(lr, true);
                        break;
                    case 3:
                        SetSprites(lr, false);
                        break;
                }
            }

        }    
    }

    void SetSprites(Sprite[] newSprites, bool flipX)
    {
        if (newSprites == null || newSprites.Length == 0) return;
        currentSprites = newSprites.OrderBy(s => int.Parse(System.Text.RegularExpressions.Regex.Match(s.name, @"\d+").Value)).ToArray();
        spriteRenderer.sprite = currentSprites[0];
        spriteRenderer.flipX = flipX;
    }
}
