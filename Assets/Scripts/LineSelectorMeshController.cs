using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSelectorMeshController : MonoBehaviour
{
    public GameObject cubeMesh;
    public GameObject sphereMesh;
    private List<Mesh> meshList;
    private int meshListPointer;

    // Start is called before the first frame update
    void Start()
    {
        if (cubeMesh && sphereMesh)
        {
            meshList = new List<Mesh>()
            {
                cubeMesh.GetComponent<MeshFilter>().sharedMesh,
                sphereMesh.GetComponent<MeshFilter>().sharedMesh
            };
            meshListPointer = 0;

            this.transform.GetChild(0).gameObject.GetComponent<MeshFilter>().mesh = meshList[meshListPointer];
        }
        else 
        {
            Debug.Log("[LineSelectorMeshController] The public meshes attributes are not specified with prefeb meshes");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cubeMesh && sphereMesh)
        {
            ChangeMesh();
        }
    }

    public void ChangeMesh()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (meshListPointer < (meshList.Count - 1))
            {
                meshListPointer++;
            }
            else
            {
                meshListPointer = 0;
            }

            this.transform.GetChild(0).gameObject.GetComponent<MeshFilter>().mesh = meshList[meshListPointer];
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (meshListPointer <= 0)
            {
                meshListPointer = meshList.Count - 1;
            }
            else
            {
                meshListPointer--;
            }

            this.transform.GetChild(0).gameObject.GetComponent<MeshFilter>().mesh = meshList[meshListPointer];
        }
    }
}
