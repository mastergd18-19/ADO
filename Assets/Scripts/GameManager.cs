using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int maxSpawnPieces;

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
    }

    public void MainManu(int numberSpawnPieces)
    {
        if (numberSpawnPieces > maxSpawnPieces)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
