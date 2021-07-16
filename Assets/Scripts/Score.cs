using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text finalScoreText;
    public Text bestScoreText;
    public int myScore;
    public int bestScore;
    
    private void Start() {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            bestScore = PlayerPrefs.GetInt("BestScore");
            bestScoreText.text = "Best Score : " + bestScore.ToString();    
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = myScore.ToString();
        finalScoreText.text = "Score : " + myScore.ToString();
    }

    public void AddScore(int score)
    {
        myScore = myScore + score;
        BestScore();
    }

    public void BestScore()
    {
        if (myScore > bestScore)
        {
            bestScore = myScore;
            bestScoreText.text = "Best Score : " + bestScore.ToString();
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
    }
}
