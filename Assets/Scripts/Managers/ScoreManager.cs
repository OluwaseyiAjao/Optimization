using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;


    [SerializeField] Text text;


    void Awake ()
    {
        score = 0;
    }

    public void AddScore(int AddedScore)
    {
       score += AddedScore;
    }

    void Update ()
    {
        text.text = "Score: " + score;
    }
}
