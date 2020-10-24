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

    private void OnTrigerStay(Collider other)
    {
        Debug.Log($"other Collider {other.gameObject}");
        if (other.tag == TARGET_TAG) {
            Debug.Log("Player on the range");
            playerOnTheRange = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == TARGET_TAG) {
            Debug.Log("Player on the range");
            playerOnTheRange = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == TARGET_TAG) {
            Debug.Log("Player OUT of range");
            playerOnTheRange = false;
        }
        
    }
}
