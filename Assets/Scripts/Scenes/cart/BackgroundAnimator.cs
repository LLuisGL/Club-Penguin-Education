using UnityEngine;
using System.Collections;

public class BackgroundAnimator : MonoBehaviour
{
    private Sprite[] currentSprites;
    private int currentIndex = 0;
    private SpriteRenderer spriteRenderer;

    public float spriteChangeInterval = 0.2f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        Sprite[] straightSprites = Resources.LoadAll<Sprite>("Backgrounds/Surf/Straight");
        Sprite[] leftTurnSprites = Resources.LoadAll<Sprite>("Backgrounds/Surf/Left");
        Sprite[] rightTurnSprites = Resources.LoadAll<Sprite>("Backgrounds/Surf/right");
        currentSprites = straightSprites;

        StartCoroutine(AnimateBackground());
        StartCoroutine(SimulateDirectionChange(straightSprites, leftTurnSprites, rightTurnSprites));
    }

    IEnumerator AnimateBackground()
    {
        while (true)
        {
            if (currentSprites.Length > 0)
            {
                spriteRenderer.sprite = currentSprites[currentIndex];
                currentIndex = (currentIndex + 1) % currentSprites.Length;
            }
            yield return new WaitForSeconds(spriteChangeInterval);
        }
    }

    IEnumerator SimulateDirectionChange(Sprite[] straight, Sprite[] left, Sprite[] right)
    {
        while (true)
        {
            yield return new WaitForSeconds(8f);

            int rand = Random.Range(0, 3);
            switch (rand)
            {
                case 0:
                    SetSprites(straight);
                    Debug.Log("Cambiado a Recto");
                    break;
                case 1:
                    SetSprites(left);
                    Debug.Log("Cambiado a Izquierda");
                    break;
                case 2:
                    SetSprites(right);
                    Debug.Log("Cambiado a Derecha");
                    break;
            }
        }
    }

    void SetSprites(Sprite[] newSprites)
    {
        if (newSprites == null || newSprites.Length == 0) return;
        currentSprites = newSprites;
        currentIndex = 0;
        spriteRenderer.sprite = currentSprites[currentIndex];
    }
}
