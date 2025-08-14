using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public Text text;
    public int score;

    void Start()
    {
        score = 0;
    }

    public void addScore()
    {
        score += 20;
        text.text = score.ToString();
    }

    public void removeScore()
    {
        score -= 100;
        text.text = score.ToString();
    }
}
