using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceFalling : MonoBehaviour
{
    public float firstDuration;
    public float duration;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CheckSpeed", firstDuration, duration);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hello");
        Destroy(gameObject);
        Debug.Log("destroy");
    }

    void CheckSpeed()
    {
        Debug.Log("Position: " + transform.position);
    }
}
