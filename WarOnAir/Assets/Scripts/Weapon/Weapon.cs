using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private Camera fpsCam;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 100f;
    [SerializeField] private LayerMask targetMask;
    [SerializeField] private ParticleSystem flash;
    [SerializeField] private GameObject impactEffect;
    [SerializeField] private Transform muzzle;

    private BulletTrailEffect trailEffect;
    private float fireRate = 15f;
    private float nextTimeToFire = 0f;
    private void Start()
    {
        trailEffect = GetComponent<BulletTrailEffect>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            
        }
    }

    private void Shoot()
    {
        ParticleSystem weaponFlash = weapon.GetComponentInChildren<ParticleSystem>();
        if (weaponFlash != null)
        {
            weaponFlash.Play();
        }
        Vector3 hitPoint = weapon.transform.position + weapon.transform.forward * range;
        RaycastHit hit;
        if (Physics.Raycast(weapon.transform.position, weapon.transform.forward, out hit, range, targetMask))
        {
            hitPoint = hit.point;
            Debug.Log("Hit: " + hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
            GameObject Effect = Instantiate(impactEffect,hit.point,Quaternion.LookRotation(hit.normal));
           
            Destroy(Effect, 2f);
        }  
        trailEffect.CreateBulletTrail(muzzle, hitPoint);
    }
}
