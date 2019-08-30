using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MeshList
{ 
    Tetris_I,
    Tetris_J,
    Tetris_O,
    Tetris_S,
    Tetris_T,
    Tetris_Z
}

public class LineSelectorMeshController : MonoBehaviour
{
    public GameObject Tetris_I_Mesh;
    public GameObject Tetris_J_Mesh;
    public GameObject Tetris_O_Mesh;
    public GameObject Tetris_S_Mesh;
    public GameObject Tetris_T_Mesh;
    public GameObject Tetris_Z_Mesh;
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
            meshListPointer = 0;
            LineSelectorChangeMesh();
        }
        else 
        {
            Debug.LogError("[LineSelectorMeshController] The public meshes attributes are not specified with a prefab objects");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PrefabAssigned())
        {
            ChangeMesh();
        }
        else
        {
            Debug.LogError("[LineSelectorMeshController] The public meshes attributes are not specified with a prefab objects");
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
        return Tetris_I_Mesh && Tetris_J_Mesh && Tetris_O_Mesh && Tetris_S_Mesh && Tetris_T_Mesh && Tetris_Z_Mesh;
    }

    public void LineSelectorChangeMesh() 
    {
        switch (meshList[meshListPointer])
        {
            case MeshList.Tetris_I:
                this.gameObject.GetComponent<MeshFilter>().mesh = Tetris_I_Mesh.GetComponent<MeshFilter>().sharedMesh;
                break;
            case MeshList.Tetris_J:
                this.gameObject.GetComponent<MeshFilter>().mesh = Tetris_J_Mesh.GetComponent<MeshFilter>().sharedMesh;
                break;
            case MeshList.Tetris_O:
                this.gameObject.GetComponent<MeshFilter>().mesh = Tetris_O_Mesh.GetComponent<MeshFilter>().sharedMesh;
                break;
            case MeshList.Tetris_S:
                this.gameObject.GetComponent<MeshFilter>().mesh = Tetris_S_Mesh.GetComponent<MeshFilter>().sharedMesh;
                break;
            case MeshList.Tetris_T:
                this.gameObject.GetComponent<MeshFilter>().mesh = Tetris_T_Mesh.GetComponent<MeshFilter>().sharedMesh;
                break;
            case MeshList.Tetris_Z:
                this.gameObject.GetComponent<MeshFilter>().mesh = Tetris_Z_Mesh.GetComponent<MeshFilter>().sharedMesh;
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
