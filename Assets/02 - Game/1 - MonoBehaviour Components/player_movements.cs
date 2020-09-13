using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class player_movements : MonoBehaviour
{
    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;
    public float jumpHeight = 5.0f;
    public ForceMode forceMode = ForceMode.Force;
    public Rigidbody rbody;
    public CharacterController controller;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        controller = GetComponent<CharacterController>();
        Vector3 movement = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        movement.Normalize();
        movement *= speed;
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement *= 1.4f;
        }
        controller.SimpleMove(movement);
        
    }
    void FixedUpdate()
    {
        if (Input.GetButton("Jump"))
        {
            Debug.Log("Jump");
            bool grounded;
            //rbody.AddForce(Vector3.up, forceMode);
            grounded = (CollisionFlags.CollidedBelow) != 0;
            Debug.Log(":"+ grounded);
        }
    }
}