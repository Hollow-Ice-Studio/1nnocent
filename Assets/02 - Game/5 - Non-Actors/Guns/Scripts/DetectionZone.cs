using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    private CapsuleCollider detectionCollider;
    private Weapon owner;

    private void Awake()
    {
        detectionCollider = GetComponent<CapsuleCollider>();
        if (detectionCollider == null)
            throw new MissingComponentException("Adicione um Capsule Collider a este objeto");

        owner = GetComponentInParent<Weapon>();
        if (owner == null)
            throw new MissingComponentException("Este componente precisa ser filho de um objeto Weapon");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && owner != null)
        {
            owner.Attack(other.gameObject);
        }
    }
}
