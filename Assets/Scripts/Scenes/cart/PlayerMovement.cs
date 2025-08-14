using System.Linq;
using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using System;

public class PlayerMovement : MonoBehaviour
{
    private Sprite[] currentSprites;
    private SpriteRenderer spriteRenderer;
    private Sprite[] SSPrites;
    private Sprite[] LRSprites;
    private Sprite[] DeathSprites;
    private Coroutine animateCoroutine;
    private bool flipX;
    private char newAnimation = 's';
    public AudioSource deathMusic;
    public AudioSource switchMusic;

    public float frameDelay = 0.1f;

    public bool isAlive;

    void Start()
    {
        gameObject.tag = "straight";
        spriteRenderer = GetComponent<SpriteRenderer>();
        isAlive = true;
        SSPrites = Resources.LoadAll<Sprite>("Games/CartSurfer/Sprites/S")
            .OrderBy(s => int.Parse(Regex.Match(s.name, @"\d+").Value))
            .ToArray();

        LRSprites = Resources.LoadAll<Sprite>("Games/CartSurfer/Sprites/LR")
            .OrderBy(s => int.Parse(Regex.Match(s.name, @"\d+").Value))
            .ToArray();

        DeathSprites = Resources.LoadAll<Sprite>("Games/CartSurfer/Sprites/DeathAnimation")
            .OrderBy(s => int.Parse(Regex.Match(s.name, @"\d+").Value))
            .ToArray();

        currentSprites = SSPrites;
        newAnimation = 's';

        animateCoroutine = StartCoroutine(AnimateSprites());
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            switchMusic.Play();
            currentSprites = LRSprites;
            newAnimation = 'l';
            gameObject.tag = "left";
            flipX = false;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            switchMusic.Play();
            currentSprites = LRSprites;
            newAnimation = 'r';
            gameObject.tag = "right";
            flipX = true;
        }
        else
        {
            currentSprites = SSPrites;
            newAnimation = 's';
            gameObject.tag = "straight";
            flipX = false;
        }
    }

    IEnumerator AnimateSprites()
    {
        int index = 0;

        while (true)
        {
            if (isAlive)
            {
                Sprite[] localSprites = currentSprites;

                if (index >= localSprites.Length)
                    index = 0;

                spriteRenderer.sprite = localSprites[index];
                spriteRenderer.flipX = flipX;

                if (newAnimation == 's')
                {
                    index++;
                    if (index >= localSprites.Length)
                        index = 0;
                }
                else
                {
                    if (index < localSprites.Length - 1)
                    {
                        index++;
                    }
                }

                yield return new WaitForSeconds(frameDelay);
            }
        }
    }

    public IEnumerator DeathAnimation()
    {
        deathMusic.Play();
        if (animateCoroutine != null)
            StopCoroutine(animateCoroutine);

        isAlive = false;

        foreach (Sprite frame in DeathSprites)
        {
            spriteRenderer.sprite = frame;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
