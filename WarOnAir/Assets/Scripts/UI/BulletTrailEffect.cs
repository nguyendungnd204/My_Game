using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrailEffect : MonoBehaviour
{
    [SerializeField] private GameObject bulletTrail;

    public void CreateBulletTrail(Transform spawnPoint, Vector3 hitPoint)
    {
        GameObject clone = Instantiate(bulletTrail, spawnPoint.position, bulletTrail.transform.rotation);
        MoveTrail trail = clone.GetComponent<MoveTrail>();
        trail.hitPoint = hitPoint;

    }
}
