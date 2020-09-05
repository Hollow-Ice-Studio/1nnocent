using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class turretBehaviour : MonoBehaviour
{
    [SerializeField]
    Transform playerReference;
    [SerializeField]
    GameObject enemyBullet;
    [Range(1,10)]
    public float shootingFrequency;
    // Start is called before the first frame update
    void Awake()
    {
        /*var lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = false;
        lineRenderer.SetPosition(1, Vector3.forward * 10);
        lineRenderer.startWidth = 0.1f;*/
        StartCoroutine(Shoot(shootingFrequency));
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.LookAt(playerReference);
    }
     IEnumerator Shoot(float waitTime)
    {
        while (true)
        {
            GameObject.Instantiate(enemyBullet, this.transform.position + this.transform.forward, this.transform.rotation, null);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
