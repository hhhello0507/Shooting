using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField]
    private Text currentScoreUI;

    private int currentScore;
    public int Score
    {
        get => currentScore;
        set
        {
            currentScore = value;
            currentScoreUI.text = $"현재 점수: {currentScore}";

            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                bestScoreUI.text = $"최고 점수: {bestScore}";

                PlayerPrefs.SetInt("Best Score", bestScore);
            }
        }
    }

    [SerializeField]
    private Text bestScoreUI;
    private int bestScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreUI.text = $"최고 점수: {bestScore}";
    }
}