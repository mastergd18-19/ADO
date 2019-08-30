using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int maxSpawnPieces;
    private int score;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (maxSpawnPieces <= 0)
        {
            maxSpawnPieces = 1;
        }
        score = 0;
    }

    public void updateScore(int newScore)
    {
        score += newScore;
    }

    public int getScore()
    {
        return score;
    }

    public void EndGame(int numberSpawnPieces)
    {
        if (numberSpawnPieces > maxSpawnPieces)
        {
            SceneManager.LoadScene("ScoreMenu");
        }
    }
}
