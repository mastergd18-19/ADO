using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSelectorDestroyPiece : MonoBehaviour
{
    private bool pieceCanBeDestroyed;
    private GameObject pieceToDestroy;
    public float penaltyCountDown;
    public float penalty;

    // Start is called before the first frame update
    void Start()
    {
        pieceCanBeDestroyed = false;
        pieceToDestroy = null;
        penaltyCountDown = 0.0f;
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
        if (Input.GetKey(KeyCode.Space))
        {
            //Debug.Log(pieceCanBeDestroyed + " " + penaltyCountDown);

            if (pieceCanBeDestroyed == true && penaltyCountDown == 0.0f)
            {
                Destroy(pieceToDestroy);
                pieceToDestroy = null;
            }
            else if (penaltyCountDown == 0.0f)
            {
                penaltyCountDown = penalty;
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

    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Piece" && Input.GetKey(KeyCode.Space) && pieceCanBeDestroyed == true)
        {
            if (penaltyCountDown == 0.0f)
            {
                Destroy(other.gameObject);
            }
            else
            {
                penaltyCountDown = penalty;
                //CoUpdatePenaltyCountDown();
            }
        }
    }
    */

    /*
    IEnumerator CoUpdatePenaltyCountDown()
    {
        while (penaltyCountDown > 0)
        {
            yield return new WaitForSeconds(1);
            penaltyCountDown--;
        }
    }
    */
}
