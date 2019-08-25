using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSelectorDestroyPiece : MonoBehaviour
{
    public float penalty;
    private float penaltyCountDown;
    private bool pieceCanBeDestroyed;
    private GameObject pieceToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        if (penalty < 0)
        {
            penalty = 5.0f;
        }
        penaltyCountDown = 0.0f;
        pieceCanBeDestroyed = false;
        pieceToDestroy = null;
    }

    // Update is called once per frame
    void Update()
    {
        DestroyPiece();
        UpdatePenaltyCountDown();
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

    public void DestroyPiece()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (penaltyCountDown <= 0.0f)
            {
                if (pieceCanBeDestroyed == true)
                {
                    Destroy(pieceToDestroy);
                    pieceToDestroy = null;
                    pieceCanBeDestroyed = false;
                }
                else
                {
                    penaltyCountDown = penalty;
                }
            }
        }
    }

    public void UpdatePenaltyCountDown()
    {
        if (penaltyCountDown > 0.0f)
        {
            penaltyCountDown -= Time.deltaTime;
        }
        else
        {
            penaltyCountDown = 0.0f;
        }
    }
}
