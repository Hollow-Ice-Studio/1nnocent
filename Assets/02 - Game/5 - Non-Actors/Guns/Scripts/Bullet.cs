using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private CapsuleCollider cc;
    private Rigidbody rb;

    private Vector3 targetPos = Vector3.zero;
    public Vector3 TargetPos { set { targetPos = value; } }
    private Vector3 originPos = Vector3.zero;
    public Vector3 OriginPos { set { originPos = value; } }

    [Range(1, 100)]
    [SerializeField] float FORCE = 5f;

    private void Awake()
    {
        cc = GetComponent<CapsuleCollider>();
        if (cc == null)
            throw new MissingComponentException("Adicione um Capsule Collider ao objeto");

        rb = GetComponent<Rigidbody>();
        if (rb == null)
            throw new MissingComponentException("Adicione um Rigid Body ao objeto");
        
    }

    private void LateUpdate()
    {

        if (targetPos != Vector3.zero)
        {
            // Shoot();
        }

    }

    public void Shoot()
    {
        rb.AddForce((targetPos - transform.localPosition) * FORCE, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
