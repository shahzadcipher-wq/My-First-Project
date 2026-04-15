using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoretext;
    [SerializeField] private Text bestScoretext;
    private float score = 0f;
    private int bestScore = 0;
    private bool bestScoreSaved = false;

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoretext.text = "Best Score: " + bestScore.ToString();
    }

    private void Update()
    {
        if(GameManager.Instance.isGameOver==true)
        {
            SaveBestScore();
            return;
        }
            
        score += Time.deltaTime * 10; // Increase score over time
        scoretext.text = "Score: " + score.ToString("0");
    }

    private void SaveBestScore()
    {
        if(bestScoreSaved)
        {
            return;
        }
        bestScoreSaved = true;
        int currentScore = (int)score;
        if(currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
        }

        bestScoretext.text = "Best: " + bestScore.ToString();
    }

}
