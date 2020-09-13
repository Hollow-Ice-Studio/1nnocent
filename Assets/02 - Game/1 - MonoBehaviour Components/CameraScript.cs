using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float speed = 10.0f;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        //transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
        //                            0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
        Vector3 v3 = new Vector3((-Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed),
                                    -Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, 0);
        v3.Normalize();
        transform.Rotate(-Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed, 0, 0, Space.Self);
        transform.Rotate(0, -Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, 0, Space.Self);
        //Debug.Log("Y " + Input.GetAxisRaw("Mouse Y"));
        //Debug.Log("X " + Input.GetAxisRaw("Mouse X"));
        Debug.Log("X " + Input.mousePosition);
    }

}