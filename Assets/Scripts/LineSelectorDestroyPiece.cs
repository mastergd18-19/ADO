using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineSelectorDestroyPiece : MonoBehaviour
{
    public Text scoreText;
    public Text penaltyText;
    public float penaltyTimer;
    private float penaltyCountDown;
    private bool pieceCanBeDestroyed;
    private GameObject pieceToDestroy;
    private int increaseScore;
    private int decreaseScore;

    // Start is called before the first frame update
    void Start()
    {
        if (scoreText)
        {
            scoreText.enabled = true;
        }
        else
        {
            Debug.LogError("[LineSelectorDestroyPiece] The public score text attributes is not specified with prefab objects");
        }
        if (penaltyText)
        {
            penaltyText.enabled = false;
        }
        else
        {
            Debug.LogError("[LineSelectorDestroyPiece] The public penalty text attributes is not specified with prefab objects");
        }
        if (penaltyTimer < 0)
        {
            penaltyTimer = 0.0f;
        }
        penaltyCountDown = 0.0f;
        pieceCanBeDestroyed = false;
        pieceToDestroy = null;
        increaseScore = 10;
        decreaseScore = -10;
    }

    // Update is called once per frame
    void Update()
    {
        DestroyPiece();
        UpdatePenaltyCountDown();
    }

    public void DestroyPiece()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (penaltyCountDown <= 0.0f)
            {
                if (pieceCanBeDestroyed == true && SameMeshes())
                {
                    Destroy(pieceToDestroy);
                    pieceToDestroy = null;
                    pieceCanBeDestroyed = false;
                    GameManager.Instance.updateScore(increaseScore);
                    if (scoreText)
                    {
                        scoreText.text = "Score: " + GameManager.Instance.getScore();
                    }
                    else
                    {
                        Debug.LogError("[LineSelectorDestroyPiece] The public score text attributes is not specified with prefab objects");
                    }
                }
                else
                {
                    penaltyCountDown = penaltyTimer;
                    GameManager.Instance.updateScore(decreaseScore);
                    if (scoreText)
                    {
                        scoreText.text = "Score: " + GameManager.Instance.getScore();
                    }
                    else
                    {
                        Debug.LogError("[LineSelectorDestroyPiece] The public score text attributes is not specified with prefab objects");
                    }
                    if (penaltyText)
                    {
                        penaltyText.enabled = true;
                        penaltyText.text = "Penalty: " + (int)penaltyCountDown;
                    }
                    else
                    {
                        Debug.LogError("[LineSelectorDestroyPiece] The public penalty text attributes is not specified with prefab objects");
                    }
                }
            }
        }
    }

    public void UpdatePenaltyCountDown()
    {
        if (penaltyCountDown > 0.0f)
        {
            penaltyCountDown -= Time.deltaTime;
            if (penaltyText)
            {
                penaltyText.text = "Penalty: " + (int)penaltyCountDown;
            }
            else
            {
                Debug.LogError("[LineSelectorDestroyPiece] The public penalty text attributes is not specified with prefab objects");
            }
        }
        else
        {
            penaltyCountDown = 0.0f;
            if (penaltyText)
            {
                penaltyText.enabled = false;
                penaltyText.text = "Penalty: " + (int)penaltyCountDown;
            }
            else
            {
                Debug.LogError("[LineSelectorDestroyPiece] The public penalty text attributes is not specified with prefab objects");
            }
        }
    }

    public bool SameMeshes()
    {
        MeshList LineSelectorMesh = this.gameObject.GetComponent<LineSelectorMeshController>().GetPieceMesh();
        MeshList PieceMesh = pieceToDestroy.gameObject.GetComponent<PieceMeshController>().GetPieceMesh();
        return LineSelectorMesh == PieceMesh;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Piece")
        {
            pieceCanBeDestroyed = true;
            pieceToDestroy = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Piece")
        {
            pieceCanBeDestroyed = false;
            pieceToDestroy = null;
        }
    }
}
