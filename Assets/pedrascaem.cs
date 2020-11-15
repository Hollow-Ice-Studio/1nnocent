using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pedrascaem : MonoBehaviour
{
    public GameObject trigger;
    public GameObject suporte;
    

    Animator suporteAnim;
    

    // Start is called before the first frame update
    void Start()
    {
        suporteAnim = suporte.GetComponent<Animator>();
        

    }

    void OnTriggerEnter(Collider coll)
    {
        Debug.Log("Entrou");

        if (coll.gameObject.tag == "Player")
        {
            Fallrocks(true);
        }
    }

    void Fallrocks(bool state)
    {
        suporteAnim.SetBool("fall", state);
        
    }

}
