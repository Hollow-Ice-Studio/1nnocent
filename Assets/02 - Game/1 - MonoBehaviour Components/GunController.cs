using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class GunController : MonoBehaviour
{
    [SerializeField]
    Transform gunTarget, bulletHole,character;
    [SerializeField]
    Text ammoUiTextElement;
    public float impulse = 50, distance = 1000, totalAmmo = 16, currentAmmo = 0;//abstrair info de multiplas armas
    public string gunDescription;
    AudioSource[] gunAudioSource;
    void Awake()
    {
        gunAudioSource = GetComponents<AudioSource>();
        UpdateAmmoUI();
    }

    void Update()
    {
        character.LookAt(gunTarget);
        Debug.DrawRay(bulletHole.position, transform.forward * 10, Color.green);
        if (Input.GetMouseButtonDown(0))
        {
            UpdateAmmoUI();
        }
    }

    public void Shoot()
    {
        LayerMask enemyMask = LayerMask.GetMask("Enemy");
        Ray ray = new Ray(bulletHole.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, distance))
        {
            var collided = hitInfo.collider;
            var rb = collided.GetComponent<Rigidbody>();
            if (rb)
                rb.AddForce(hitInfo.normal * impulse * -1);
            if (collided.tag == "Target")
            {
                Debug.Log("Target Shooted");
                var vic = GetComponent<VictoryCondition>();
                collided.tag = "Untagged";
                var material = collided.GetComponent<MeshRenderer>().material;
                material.color = new Color(0, 1, 0);
                vic.IncreaseTarget();
            }
        }
    }

    void PlayShootSound()
    {
        gunAudioSource[0].Play();
    }
    void PlayReloadingSound()
    {
        gunAudioSource[1].Play();
    }

    void UpdateAmmoUI()
    {
        if (currentAmmo == 0)
        {
            currentAmmo = totalAmmo;
            PlayReloadingSound();
        }
        else
        {
            currentAmmo--;
            PlayShootSound();
            Shoot();
        }
        ammoUiTextElement.text = $"{gunDescription} {currentAmmo}/{totalAmmo}";
    }
}
