using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMeshController : MonoBehaviour
{
    public GameObject capsuleMesh;
    public Material capsuleMaterial;
    public GameObject cubeMesh;
    public Material cubeMaterial;
    public GameObject cylinderMesh;
    public Material cylinderMaterial;
    public GameObject sphereMesh;
    public Material sphereMaterial;
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
            meshListPointer = Random.Range(0, meshList.Count);
            LineSelectorChangeMesh();
        }
        else
        {
            Debug.Log("[PieceMeshController] The public meshes attributes are not specified with prefeb meshes");
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
                this.gameObject.GetComponent<MeshRenderer>().material = capsuleMaterial;
                break;
            case MeshList.Cube:
                this.gameObject.GetComponent<MeshFilter>().mesh = cubeMesh.GetComponent<MeshFilter>().sharedMesh;
                this.gameObject.GetComponent<MeshRenderer>().material = cubeMaterial;
                break;
            case MeshList.Cylinder:
                this.gameObject.GetComponent<MeshFilter>().mesh = cylinderMesh.GetComponent<MeshFilter>().sharedMesh;
                this.gameObject.GetComponent<MeshRenderer>().material = cylinderMaterial;
                break;
            case MeshList.Sphere:
                this.gameObject.GetComponent<MeshFilter>().mesh = sphereMesh.GetComponent<MeshFilter>().sharedMesh;
                this.gameObject.GetComponent<MeshRenderer>().material = sphereMaterial;
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