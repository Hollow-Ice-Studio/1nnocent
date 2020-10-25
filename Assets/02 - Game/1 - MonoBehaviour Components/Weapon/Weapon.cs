﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    protected GameObject owner;
    protected SphereCollider grabCollider;
    protected CapsuleCollider detectionCollider;

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
    }
}
