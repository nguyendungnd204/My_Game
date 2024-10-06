using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] private Transform weaponRight;
    [SerializeField] private Transform weaponLeft;
    [SerializeField] private Camera fpsCam;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 100f;
    [SerializeField] private LayerMask targetMask;
    [SerializeField] private ParticleSystem flash;
    [SerializeField] private GameObject impactEffect;

    private float fireRate = 15f;
    private float nextTimeToFire = 0f;

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot(weaponRight);
            Shoot(weaponLeft);
        }
    }

    private void Shoot(Transform weapon)
    {
        ParticleSystem weaponFlash = weapon.GetComponentInChildren<ParticleSystem>();
        if (weaponFlash != null)
        {
            weaponFlash.Play();
        }
        RaycastHit hit;
        if (Physics.Raycast(weapon.position, weapon.forward, out hit, range, targetMask))
        {
            Debug.Log("Hit: " + hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
            GameObject Effect = Instantiate(impactEffect,hit.point,Quaternion.LookRotation(hit.normal));
            Destroy(Effect, 2f);
        }
    }
}
