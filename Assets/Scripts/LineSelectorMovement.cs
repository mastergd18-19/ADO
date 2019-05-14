using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSelectorMovement : MonoBehaviour
{
    private Vector3 line1;
    private Vector3 line2;
    private Vector3 line3;
    private Vector3 line4;
    private Vector3 line5;
    private bool applyMovement;

    // Start is called before the first frame update
    void Start()
    {
        line1 = new Vector3(-4.0f, 0.5f, -28.0f);
        line2 = new Vector3(-2.0f, 0.5f, -28.0f);
        line3 = new Vector3(0.0f, 0.5f, -28.0f);
        line4 = new Vector3(2.0f, 0.5f, -28.0f);
        line5 = new Vector3(4.0f, 0.5f, -28.0f);
        applyMovement = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (applyMovement)
        {
            Movement();
        }
    }

    public void Movement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MovementLeft();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MovementRight();
        }
    }

    public void MovementLeft()
    {
        switch (this.gameObject.GetComponent<Transform>().position.x)
        {
            case -4:
                break;
            case -2:
                this.gameObject.transform.SetPositionAndRotation(line1, Quaternion.identity);
                break;
            case 0:
                this.gameObject.transform.SetPositionAndRotation(line2, Quaternion.identity);
                break;
            case 2:
                this.gameObject.transform.SetPositionAndRotation(line3, Quaternion.identity);
                break;
            case 4:
                this.gameObject.transform.SetPositionAndRotation(line4, Quaternion.identity);
                break;
            default:
                break;
        }
    }

    public void MovementRight()
    {
        switch (this.gameObject.GetComponent<Transform>().position.x)
        {
            case -4:
                this.gameObject.transform.SetPositionAndRotation(line2, Quaternion.identity);
                break;
            case -2:
                this.gameObject.transform.SetPositionAndRotation(line3, Quaternion.identity);
                break;
            case 0:
                this.gameObject.transform.SetPositionAndRotation(line4, Quaternion.identity);
                break;
            case 2:
                this.gameObject.transform.SetPositionAndRotation(line5, Quaternion.identity);
                break;
            case 4:
                break;
            default:
                break;
        }
    }
}
