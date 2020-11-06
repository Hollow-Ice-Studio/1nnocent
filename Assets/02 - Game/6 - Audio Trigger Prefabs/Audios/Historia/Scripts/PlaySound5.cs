using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound5 : MonoBehaviour
{
    [SerializeField]
    GameObject firstStoryEnemy,nextAudioTrigger;
    private void Start()
    {
        firstStoryEnemy.SetActive(false);
        nextAudioTrigger.SetActive(false);
    }
    void OnTriggerEnter(Collider coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Pegar Arma");
            firstStoryEnemy.SetActive(true);
            nextAudioTrigger.SetActive(true);
        }
    }
}
