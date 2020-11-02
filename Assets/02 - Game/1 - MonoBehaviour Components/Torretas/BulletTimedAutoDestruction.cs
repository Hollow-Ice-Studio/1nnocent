using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTimedAutoDestruction : MonoBehaviour
{
    [SerializeField]
    [Range(0,5)]
    float timeToAutoDestruction;

    void Update()
    {
        Destroy(gameObject, timeToAutoDestruction);
    }
}
