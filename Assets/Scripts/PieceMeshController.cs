using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMeshController : MonoBehaviour
{
    public GameObject cubeMesh;
    public Material cubeMaterial;
    public GameObject sphereMesh;
    public Material sphereMaterial;
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
            meshListPointer = Random.Range(0, meshList.Count);
            LineSelectorChangeMesh();
        }
        else
        {
            Debug.Log("[LineSelectorMeshController] The public meshes attributes are not specified with prefeb meshes");
        }
    }

    public void LineSelectorChangeMesh()
    {
        switch (meshList[meshListPointer])
        {
            case MeshList.Cube:
                this.gameObject.GetComponent<MeshFilter>().mesh = cubeMesh.GetComponent<MeshFilter>().sharedMesh;
                this.gameObject.GetComponent<MeshRenderer>().material = cubeMaterial;
                break;
            case MeshList.Sphere:
                this.gameObject.GetComponent<MeshFilter>().mesh = sphereMesh.GetComponent<MeshFilter>().sharedMesh;
                this.gameObject.GetComponent<MeshRenderer>().material = sphereMaterial;
                break;
            default:
                break;
        }
    }

    public MeshList getPieceMesh()
    {
        return meshList[meshListPointer];
    }
}