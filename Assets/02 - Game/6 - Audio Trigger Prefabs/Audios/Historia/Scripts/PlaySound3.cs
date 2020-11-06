using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound3 : MonoBehaviour
{
    void OnTriggerEnter(Collider coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Perder Acesso");
        }
    }
}
