using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPersonDeath : MonoBehaviour
{
    [SerializeField]
    GameObject dyingModelPrefab;
    //TODO: Aplicar multiplas tags
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            die();
        }
    }


    void die()
    {
        GameObject.Instantiate(dyingModelPrefab, this.transform.position, this.transform.rotation, null);
        GameObject.Destroy(this.gameObject);
    }
}
