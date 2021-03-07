using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] protected GameObject owner;
    public GameObject Owner { get { return owner; } set { owner = value; } }
    protected SphereCollider grabCollider;
    protected CapsuleCollider detectionCollider;
    public AudioSource audioSource;
    [Tooltip("Área do mapa em que a arma está")]
    [SerializeField] protected MapSection mapSection;
    public MapSection MapSection { get { return mapSection; } }

    protected virtual void Awake()
    {
        CheckComponents();
    }

    protected virtual void CheckComponents()
    {
        detectionCollider = GetComponentInChildren<CapsuleCollider>();
        if (detectionCollider == null)
            throw new MissingComponentException("Adicione um Capsule Collider como filho deste objeto");
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            throw new MissingComponentException("Adicione um Audio Source como filho deste objeto");
    }

    public virtual void Attack(GameObject targetObj) { }
}
