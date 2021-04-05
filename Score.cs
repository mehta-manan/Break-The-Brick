using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    private int currentScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private int highScore;

    public int CurrentScore
    {
        get { return currentScore; }
        set { currentScore = value; }
    }

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore");

        UpdateScore("Level2", 15);
        UpdateScore("Level3", 15 + 13);
        UpdateScore("Level4", 15 + 13 + 10);
        UpdateScore("Level5", 15 + 13 + 10 + 12);
    }

    private void UpdateScore(string levelScene, int score)
    {
        if (SceneManager.GetActiveScene().name == levelScene)
        {
            currentScore = score;
            scoreText.text = "Score      " + CurrentScore.ToString();
        }
    }

    private void Update()
    {
        Debug.Log(highScore);

        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("highScore", currentScore);
        }

        highScore = PlayerPrefs.GetInt("highScore");
        highScoreText.text = "Highscore  " + highScore.ToString();
    }
}
