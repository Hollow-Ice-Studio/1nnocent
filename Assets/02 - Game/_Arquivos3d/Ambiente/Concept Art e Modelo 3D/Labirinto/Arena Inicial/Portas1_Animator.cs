using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portas1_Animator : MonoBehaviour
{
    public GameObject trigger;
    public GameObject rightDoor;
    public GameObject leftDoor;

    Animator leftAnim;
    Animator rightAnim;


    // Start is called before the first frame update
    void Start()
    {
        
        leftAnim = leftDoor.GetComponent<Animator>();
        rightAnim = rightDoor.GetComponent<Animator>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider coll)
    {
        
        if (coll.gameObject.tag == "Player")
        {
            SlideDoors(true);
        }
    }

    void OnTriggerExit(Collider coll)
    {
        /*if (coll.gameObject.tag == "Player")
        {
            SlideDoors(false);
        }*/
    }

    void SlideDoors(bool state)
    {
        leftAnim.SetBool("close", state);
        rightAnim.SetBool("close", state);

    }
}
