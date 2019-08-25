using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MeshList
{ 
    Cube,
    Sphere
}

public class LineSelectorMeshController : MonoBehaviour
{
    public GameObject cubeMesh;
    public GameObject sphereMesh;
    private List<MeshList> meshList;
    private int meshListPointer;

    // Start is called before the first frame update
    void Start()
    {
        if (cubeMesh && sphereMesh)
        {
            meshList = new List<MeshList>()
            {
                MeshList.Cube,
                MeshList.Sphere
            };
            meshListPointer = 0;
            LineSelectorChangeMesh();
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
            LineSelectorChangeMesh();
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
            LineSelectorChangeMesh();
        }
    }

    public void LineSelectorChangeMesh() 
    {
        switch (meshList[meshListPointer])
        {
            case MeshList.Cube:
                this.transform.GetChild(0).gameObject.GetComponent<MeshFilter>().mesh = cubeMesh.GetComponent<MeshFilter>().sharedMesh;
                break;
            case MeshList.Sphere:
                this.transform.GetChild(0).gameObject.GetComponent<MeshFilter>().mesh = sphereMesh.GetComponent<MeshFilter>().sharedMesh;
                break;
            default:
                break;
        }
    }
}
