using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MeshList
{ 
    Capusle,
    Cube,
    Cylinder,
    Sphere
}

public class LineSelectorMeshController : MonoBehaviour
{
    public GameObject capsuleMesh;
    public GameObject cubeMesh;
    public GameObject cylinderMesh;
    public GameObject sphereMesh;
    private List<MeshList> meshList;
    private int meshListPointer;

    // Start is called before the first frame update
    void Start()
    {
        if (PrefabAssigned())
        {
            meshList = new List<MeshList>()
            {
                MeshList.Capusle,
                MeshList.Cube,
                MeshList.Cylinder,
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
        if (PrefabAssigned())
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

    public bool PrefabAssigned()
    {
        return capsuleMesh && cubeMesh && cylinderMesh && sphereMesh;
    }

    public void LineSelectorChangeMesh() 
    {
        switch (meshList[meshListPointer])
        {
            case MeshList.Capusle:
                this.gameObject.GetComponent<MeshFilter>().mesh = capsuleMesh.GetComponent<MeshFilter>().sharedMesh;
                break;
            case MeshList.Cube:
                this.gameObject.GetComponent<MeshFilter>().mesh = cubeMesh.GetComponent<MeshFilter>().sharedMesh;
                break;
            case MeshList.Cylinder:
                this.gameObject.GetComponent<MeshFilter>().mesh = cylinderMesh.GetComponent<MeshFilter>().sharedMesh;
                break;
            case MeshList.Sphere:
                this.gameObject.GetComponent<MeshFilter>().mesh = sphereMesh.GetComponent<MeshFilter>().sharedMesh;
                break;
            default:
                break;
        }
    }

    public MeshList GetPieceMesh()
    {
        return meshList[meshListPointer];
    }
}
