using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound5B : MonoBehaviour
{
    
    void OnTriggerEnter(Collider coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Inimigo Perto");
        }
    }
}
