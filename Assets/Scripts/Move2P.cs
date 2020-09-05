using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveP2 : MonoBehaviour
{
    //:mover
    [SerializeField]
    private float movespeed;
    [SerializeField]
    private Vector3 moving;
    public Quaternion moveRotation;

    //:pular
    [SerializeField]
    private bool isgrounded;
    public float beamdistance;
    public float jumpHeight;
    public float camY;
    public Rigidbody rig;
    public Camera camera;


    void Start()
    {
        rig = GetComponent<Rigidbody>();
        moving = new Vector3(0, 0, 0);
        movespeed = 10f;
        beamdistance = 1.0f;

        jumpHeight = 0.1f;
        camera = GetComponent<Camera>();
        camY = camera.transform.eulerAngles.y;
    }

    private void Update()
    {
        //movendo

        moving.z = Input.GetAxis("Vertical") * MovingC(movespeed);
        WhichDirection();
        moving.x = Input.GetAxis("Horizontal") * MovingC(movespeed);
        //pulando
        RaycastHit beam;
        if (Physics.Raycast(transform.position, -transform.up, out beam, beamdistance))
        {
            if (beam.collider)
            {
                isgrounded = true;
            }
        }
        else
        {
            isgrounded = false;
        }
        if (isgrounded == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rig.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
            }
        }

    }
    void FixedUpdate()
    {
        rig.MovePosition(transform.position + moving);
        rig.MoveRotation(moveRotation);
    }
    public float MovingC(float input)
    {
        return input * Time.fixedDeltaTime;
    }
    void WhichDirection()
    {
        if (moving.z < 0 || moving.x != 0)
        {
            movespeed = 5f;
        }
        else if (Input.GetKey(KeyCode.LeftShift) && moving.z > 0)
        {
            movespeed = 20f;
        }
        else
        {
            movespeed = 10f;
        }
    }
}
