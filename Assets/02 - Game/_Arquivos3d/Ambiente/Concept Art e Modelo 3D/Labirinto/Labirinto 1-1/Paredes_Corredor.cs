using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Paredes_Corredor : MonoBehaviour
{
    public GameObject trigger;
    public GameObject parede1;
    public GameObject parede21;
    public GameObject parede22;
    public GameObject parede3;
    public GameObject parede4;
    public GameObject parede5;
    public GameObject parede6;

    Animator parede1Anim;
    Animator parede21Anim;
    Animator parede22Anim;
    Animator parede3Anim;
    Animator parede4Anim;
    Animator parede5Anim;
    Animator parede6Anim;

    // Start is called before the first frame update
    void Start()
    {
        parede1Anim = parede1.GetComponent<Animator>();
        parede21Anim = parede21.GetComponent<Animator>();
        parede22Anim = parede22.GetComponent<Animator>();
        parede3Anim = parede3.GetComponent<Animator>();
        parede4Anim = parede4.GetComponent<Animator>();
        parede5Anim = parede5.GetComponent<Animator>();
        parede6Anim = parede6.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            CloseWay(true);
        }

        FindObjectOfType<AudioManager>().Play("MovingDoors");
        FindObjectOfType<AudioManager>().Play("MovingDoors2");
        FindObjectOfType<AudioManager>().Play("MovingDoors3");
        FindObjectOfType<AudioManager>().Play("MovingDoors4");
        
    }

    void CloseWay(bool state)
    {
        parede1Anim.SetBool("CloseWay", state);
        parede21Anim.SetBool("CloseWay", state);
        parede22Anim.SetBool("CloseWay", state);
        parede3Anim.SetBool("CloseWay", state);
        parede4Anim.SetBool("CloseWay", state);
        parede5Anim.SetBool("CloseWay", state);
        parede6Anim.SetBool("CloseWay", state);
    }
}
