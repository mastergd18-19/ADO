using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceFalling : MonoBehaviour
{
    private int id;
    private int lane;
    private float fallingSpeed;
    private PieceSpawn pieceSpawnController;

    public void RecieveParameter(int idRecieved, int laneRecieved, float fallingSpeedRecieved, PieceSpawn pieceSpawnRecieved)
    {
        id = idRecieved;
        lane = laneRecieved;
        fallingSpeed = fallingSpeedRecieved;
        pieceSpawnController = pieceSpawnRecieved;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * fallingSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        // Eliminar id de la lista de ids del pieceSpawnController
        pieceSpawnController.RemovePieceFromSpawnPieceMap(id, lane);
    }
}
