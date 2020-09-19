using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector_Espinhos : MonoBehaviour
{

    public GameObject Espinhos;

    Animator espinhosAnim;


    // Start is called before the first frame update
    void Start()
    {
        espinhosAnim = Espinhos.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("!!!ATIVAR!!!");
        if (collider.gameObject.tag == "Player")
        {
            ativar(true);
        }
    }

    void ativar(bool state)
    {
        espinhosAnim.SetBool("ativar", state);
        
    }

    
}
