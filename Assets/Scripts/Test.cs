using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    int numerador = 4;
    int denominador = 2;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Numerador: " + numerador);
        Debug.Log("Denominador: " + denominador);

        if (denominador != 0)
        {
            Debug.Log("Resultado:" + numerador / denominador);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
