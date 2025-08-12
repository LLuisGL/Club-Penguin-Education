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
    private char direction = 's';
    private bool isSpriteRunning = false;

    public float spriteChangeInterval = .5f;
    public GameManager myGameManager;

    void Start()
    {
        gameObject.tag = "straight";
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
            int index = 0;
            bool flag = false;
            foreach(Sprite sprite in currentSprites) {
                if(sprite.name.StartsWith("1lr"))
                {
                    flag = true;
                }
                if (flag && index >= 37)
                {

                    if(spriteRenderer.flipX)
                    {
                        gameObject.tag = "left";     
                    }else
                    {
                        gameObject.tag = "right";
                    }
                                        
                }
                else
                {
                    gameObject.tag = "straight";
                }
                
                myGameManager.AddScore();
                spriteRenderer.sprite = sprite;
                index++;
                yield return new WaitForSeconds(0.065f);
            }
            isSpriteRunning = false;
        }
    }
                  

    IEnumerator SimulateDirectionChange(Sprite[] straight, Sprite[] lr)
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
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
