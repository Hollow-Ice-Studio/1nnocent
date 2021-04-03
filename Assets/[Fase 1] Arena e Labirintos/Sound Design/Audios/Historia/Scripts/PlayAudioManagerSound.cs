using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;

namespace innocent
{
    public class PlayAudioManagerSound : MonoBehaviour
    {
        [SerializeField] private string NomeDoSomConfigurado;
        void OnTriggerEnter(Collider coll)
        {
            if (coll.gameObject.tag == "Player")
            {
                FindObjectOfType<AudioManager>().Play(NomeDoSomConfigurado);
                Destroy(gameObject);
            }
        }
    }
}