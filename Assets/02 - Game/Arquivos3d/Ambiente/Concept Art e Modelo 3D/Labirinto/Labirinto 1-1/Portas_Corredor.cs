using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portas_Corredor : MonoBehaviour
{
    public GameObject trigger;
    public GameObject porta1;
    public GameObject porta2;
    public GameObject porta3;
    public GameObject porta4;
    public GameObject porta5;

    Animator porta1Anim;
    Animator porta2Anim; 
    Animator porta3Anim;
    Animator porta4Anim;
    Animator porta5Anim;

    // Start is called before the first frame update
    void Start()
    {
        porta1Anim = porta1.GetComponent<Animator>();
        porta2Anim = porta2.GetComponent<Animator>();
        porta3Anim = porta3.GetComponent<Animator>();
        porta4Anim = porta4.GetComponent<Animator>();
        porta5Anim = porta5.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            OpenWay(true);
        }
    }

    void OpenWay(bool state)
    {
        porta1Anim.SetBool("OpenWay", state);
        porta2Anim.SetBool("OpenWay", state);
        porta3Anim.SetBool("OpenWay", state);
        porta4Anim.SetBool("OpenWay", state);
        porta5Anim.SetBool("OpenWay", state);
    }

}
