using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMeshController : MonoBehaviour
{
    public GameObject Tetris_I_Mesh;
    public Material Tetris_I_Material;
    public GameObject Tetris_J_Mesh;
    public Material Tetris_J_Material;
    public GameObject Tetris_O_Mesh;
    public Material Tetris_O_Material;
    public GameObject Tetris_S_Mesh;
    public Material Tetris_S_Material;
    public GameObject Tetris_T_Mesh;
    public Material Tetris_T_Material;
    public GameObject Tetris_Z_Mesh;
    public Material Tetris_Z_Material;
    private List<MeshList> meshList;
    private int meshListPointer;

    // Start is called before the first frame update
    void Start()
    {
        if (PrefabAssigned())
        {
            meshList = new List<MeshList>()
            {
                MeshList.Tetris_I,
                MeshList.Tetris_J,
                MeshList.Tetris_O,
                MeshList.Tetris_S,
                MeshList.Tetris_T,
                MeshList.Tetris_Z
            };
            meshListPointer = Random.Range(0, meshList.Count);
            LineSelectorChangeMesh();
        }
        else
        {
            Debug.LogError("[PieceMeshController] The public meshes and materials attributes are not specified with prefab objects");
        }
    }

    public bool PrefabAssigned()
    {
        bool meshesAssigned = false;
        bool materialsAssigned = false;

        if (Tetris_I_Mesh && Tetris_J_Mesh && Tetris_O_Mesh && Tetris_S_Mesh && Tetris_T_Mesh && Tetris_Z_Mesh)
        {
            meshesAssigned = true;
        }
        if (Tetris_I_Material && Tetris_J_Material && Tetris_O_Material && Tetris_S_Material && Tetris_T_Material && Tetris_Z_Material)
        {
            materialsAssigned = true;
        }
        return meshesAssigned && materialsAssigned;
    }

    public void LineSelectorChangeMesh()
    {
        switch (meshList[meshListPointer])
        {
            case MeshList.Tetris_I:
                this.gameObject.GetComponent<MeshFilter>().mesh = Tetris_I_Mesh.GetComponent<MeshFilter>().sharedMesh;
                this.gameObject.GetComponent<MeshRenderer>().material = Tetris_I_Material;
                break;
            case MeshList.Tetris_J:
                this.gameObject.GetComponent<MeshFilter>().mesh = Tetris_J_Mesh.GetComponent<MeshFilter>().sharedMesh;
                this.gameObject.GetComponent<MeshRenderer>().material = Tetris_J_Material;
                break;
            case MeshList.Tetris_O:
                this.gameObject.GetComponent<MeshFilter>().mesh = Tetris_O_Mesh.GetComponent<MeshFilter>().sharedMesh;
                this.gameObject.GetComponent<MeshRenderer>().material = Tetris_O_Material;
                break;
            case MeshList.Tetris_S:
                this.gameObject.GetComponent<MeshFilter>().mesh = Tetris_S_Mesh.GetComponent<MeshFilter>().sharedMesh;
                this.gameObject.GetComponent<MeshRenderer>().material = Tetris_S_Material;
                break;
            case MeshList.Tetris_T:
                this.gameObject.GetComponent<MeshFilter>().mesh = Tetris_S_Mesh.GetComponent<MeshFilter>().sharedMesh;
                this.gameObject.GetComponent<MeshRenderer>().material = Tetris_T_Material;
                break;
            case MeshList.Tetris_Z:
                this.gameObject.GetComponent<MeshFilter>().mesh = Tetris_Z_Mesh.GetComponent<MeshFilter>().sharedMesh;
                this.gameObject.GetComponent<MeshRenderer>().material = Tetris_Z_Material;
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