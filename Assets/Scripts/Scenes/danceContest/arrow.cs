using System.Collections;
using System.Linq;
using UnityEngine;

public class arrow : MonoBehaviour
{
    private float speed = 5f;
    public string path;
    public Sprite[] currentSprites;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentSprites = Resources.LoadAll<Sprite>(path);
        currentSprites = currentSprites.OrderBy(s => int.Parse(System.Text.RegularExpressions.Regex.Match(s.name, @"\d+").Value)).ToArray();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }


    public IEnumerator DestroyArrow()
    {
        speed = 0f;
        int index = 0;
        foreach (Sprite frame in currentSprites)
        {
            UnityEngine.Debug.Log(index);
            yield return new WaitForSeconds(0.055f);
            spriteRenderer.sprite = frame;
            index++;
        }

        Destroy(gameObject);
    }
}
