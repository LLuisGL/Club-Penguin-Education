using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class animatePlayert : MonoBehaviour
{
    private Sprite[] move_1;
    private Sprite[] move_2;
    private Sprite[] move_3;
    private Sprite[] move_4;
    private Sprite[] move_5;
    private Sprite[] move_6;
    private Sprite[] move_7;
    private Sprite[] move_8;

    private SpriteRenderer spriteRenderer;
    private Sprite[] currentSprites;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        move_1 = Resources.LoadAll<Sprite>("Games/DanceContest/player/move_1");
        move_2 = Resources.LoadAll<Sprite>("Games/DanceContest/player/move_2");
        move_3 = Resources.LoadAll<Sprite>("Games/DanceContest/player/move_3");
        move_4 = Resources.LoadAll<Sprite>("Games/DanceContest/player/move_4");
        move_5 = Resources.LoadAll<Sprite>("Games/DanceContest/player/move_5");
        move_6 = Resources.LoadAll<Sprite>("Games/DanceContest/player/move_6");
        move_7 = Resources.LoadAll<Sprite>("Games/DanceContest/player/move_7");
        move_8 = Resources.LoadAll<Sprite>("Games/DanceContest/player/move_8");

        StartCoroutine(animateRandom());
    }



    IEnumerator animateRandom()
    {
        while (true)
        {
            int rand = UnityEngine.Random.Range(0, 8);
            switch(rand)
            {
                case 0:
                    currentSprites = move_1;
                    break;
                case 1:
                    currentSprites = move_2;
                    break;
                case 2:
                    currentSprites = move_3;
                    break;
                case 3:
                    currentSprites = move_4;
                    break;
                case 4:
                    currentSprites = move_5;
                    break;
                case 5:
                    currentSprites = move_6;
                    break;
                case 6:
                    currentSprites = move_7;
                    break;
                case 7:
                    currentSprites = move_8;
                    break;
            }

            currentSprites = currentSprites.OrderBy(s => int.Parse(System.Text.RegularExpressions.Regex.Match(s.name, @"\d+").Value)).ToArray();

            foreach (Sprite frame in currentSprites)
            {
                spriteRenderer.sprite = frame;
                yield return new WaitForSeconds(0.075f);
            }
        }
    }
}
