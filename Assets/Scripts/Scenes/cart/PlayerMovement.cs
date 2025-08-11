using System.Linq;
using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class PlayerMovement : MonoBehaviour
{
    private Sprite[] currentSprites;
    private SpriteRenderer spriteRenderer;
    private Sprite[] SSPrites;
    private Sprite[] LRSprites;
    private bool flipX;
    private char currentlyAnimation = 's';
    private char newAnimation = 's';

    public float frameDelay = 0.1f; 

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        SSPrites = Resources.LoadAll<Sprite>("Games/CartSurfer/Sprites/S")
            .OrderBy(s => int.Parse(Regex.Match(s.name, @"\d+").Value))
            .ToArray();

        LRSprites = Resources.LoadAll<Sprite>("Games/CartSurfer/Sprites/LR")
            .OrderBy(s => int.Parse(Regex.Match(s.name, @"\d+").Value))
            .ToArray();

        currentSprites = SSPrites;
        newAnimation = 's';

        StartCoroutine(AnimateSprites());
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            currentSprites = LRSprites;
            newAnimation = 'l';
            flipX = false;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            currentSprites = LRSprites;
            newAnimation = 'r';
            flipX = true;
        }
        else
        {
            currentSprites = SSPrites;
            newAnimation = 's';
            flipX = false;
        }
    }

    IEnumerator AnimateSprites()
    {
        int index = 0;

        while (true)
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
