using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaCollider : MonoBehaviour
{
    private const string TARGET_TAG = "Player";
    private CapsuleCollider sc;
    [SerializeField] private bool playerOnTheRange;
    public bool PlayerOnTheRange { get { return playerOnTheRange; } }

    private void Awake()
    {
        sc = GetComponent<CapsuleCollider>();
        if (sc == null)
            throw new MissingComponentException("Adicione um Sphere Collider ao objeto");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == TARGET_TAG) {
            playerOnTheRange = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == TARGET_TAG) {
            playerOnTheRange = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == TARGET_TAG) {
            playerOnTheRange = false;
        }
        
    }
}
