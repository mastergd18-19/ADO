using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSelectorDestroyPiece : MonoBehaviour
{
    public float penaltyTimer;
    private float penaltyCountDown;
    private bool penalty;
    private bool pieceCanBeDestroyed;
    private GameObject pieceToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        if (penaltyTimer < 0)
        {
            penaltyTimer = 0.0f;
        }
        penaltyCountDown = 0.0f;
        penalty = false;
        pieceCanBeDestroyed = false;
        pieceToDestroy = null;
    }

    // Update is called once per frame
    void Update()
    {
        DestroyPiece();
        UpdatePenaltyCountDown();
        Debug.Log("Penalty: " + penalty + " PenaltyCountDown: " + penaltyCountDown);
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
                }
                else
                {
                    penaltyCountDown = penaltyTimer;
                    penalty = true;
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
            penalty = false;
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
