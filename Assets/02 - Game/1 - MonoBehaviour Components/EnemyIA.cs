using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class EnemyIA : MonoBehaviour
{
    public Detector detector;
   public Transform playerTransform;
    UnityEngine.AI.NavMeshAgent myNavMesh;
    public float checkRate = 0.01f;
    float nextCheck;

    Transform lastPlayerTransform;
    public bool fire;
    public bool detected;
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player").activeInHierarchy)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            myNavMesh = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
            lastPlayerTransform.position = transform.position;
        }
            detector = GetComponent<Detector>();
    }
    void Update()
    {
        detected = detector.detect;
        if (detected == true)
        {
            if (Time.time > nextCheck)
            {
                nextCheck = Time.time + checkRate;
                FollowPlayer();
            }
        }
        else
        {
            lastPlayerTransform.position = playerTransform.position;
            if (Time.time > nextCheck)
            {
                nextCheck = Time.time + checkRate;
                DontFollowPlayer();
            }
        }
    }
    void FollowPlayer()
    {
        myNavMesh.transform.LookAt(playerTransform);
        myNavMesh.destination = playerTransform.position;
    }
    private void DontFollowPlayer()
    {   
        myNavMesh.transform.LookAt(playerTransform);
        myNavMesh.destination = lastPlayerTransform.position;
    }
}
