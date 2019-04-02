using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void LoadScene01(string scene2beLoaded)
    {
        SceneManager.LoadScene(scene2beLoaded);
    }
}
