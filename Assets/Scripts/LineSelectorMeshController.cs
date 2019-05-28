using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSelectorMeshController : MonoBehaviour
{
    private enum meshes {cube, sphere};
    private List<meshes> meshList;
    private int meshListPointer;

    // Start is called before the first frame update
    void Start()
    {
        meshList = new List<meshes>() {meshes.cube, meshes.sphere};
        meshListPointer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeMesh();
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
            Mesh meshToChange = new Mesh();
            switch (meshList[meshListPointer])
            {
                case meshes.cube:
                    //meshToChange.;
                    break;
                case meshes.sphere:
                    //meshToChange.sphere;
                    break;
                default:
                    break;
            }
            //GetComponentInChildren<MeshFilter>().mesh = GameObject.CreatePrimitive(PrimitiveType.Cube);
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
            Debug.Log(meshList[meshListPointer]);
        }
    }
}
