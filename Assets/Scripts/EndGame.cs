using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (scoreText)
        {
            scoreText.enabled = true;
            scoreText.text = "Score: " + GameManager.Instance.getScore();
        }
        else
        {
            Debug.LogError("[LineSelectorDestroyPiece] The public score text attributes is not specified with prefab objects");
        }
    }
}
