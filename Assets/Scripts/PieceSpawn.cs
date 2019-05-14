using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawn : MonoBehaviour
{
    public GameObject myPiece;
    public float spawnTime;
    private float spawnCurrentTime;

    // Start is called before the first frame update
    void Start()
    {
        spawnCurrentTime = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    public void Spawn()
    {
        if (spawnCurrentTime < spawnTime)
        {
            spawnCurrentTime += Time.deltaTime;
        }
        else
        {
            Instantiate(myPiece, this.gameObject.GetComponent<Transform>().position, Quaternion.identity);
            spawnCurrentTime = 0;
        }
    }
}
