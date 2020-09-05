using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ThirdPersonCharacterController : MonoBehaviour
{
    public float speed= 1, jumpHeight=1;

    public bool isgrounded;
    float beamdistance;
    Rigidbody rig;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        beamdistance = transform.localScale.y + .2f;
    }
    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        IsPlayerOnGround();
        Debug.DrawRay(transform.position + (transform.up * beamdistance), -transform.up * beamdistance*2, Color.red);
    }

    void PlayerMovement() {
        float z_move = Input.GetAxis("Vertical");
        float x_move = Input.GetAxis("Horizontal");
        Vector3 vect3 = new Vector3(x_move, 0f, z_move);
        vect3.Normalize();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(vect3 * Time.deltaTime * speed * 2, Space.Self);
        }
        else
        {
            transform.Translate(vect3 * Time.deltaTime * speed, Space.Self);
        }
        
    }

    //Esse método é ativado a partir da animação de pulo
    private void PlayerJumpByAnimation()
    {
        //nao necessita de getKey no método de pulo se estiver ativando via animação
        if (isgrounded)
        {
            Debug.Log(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y));
            rig.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }
    }

    private void IsPlayerOnGround()
    {
        RaycastHit beam;
        if (Physics.Raycast(transform.position + (transform.up * beamdistance), -transform.up, out beam, beamdistance * 2))
        {
            isgrounded = true;
        }
        else
        {
            isgrounded = false;
        }
    }
}
