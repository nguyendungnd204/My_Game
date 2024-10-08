using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrail : MonoBehaviour
{
    public Vector3 hitPoint;
    public float timeNeededToReach;
    private void Start()
    {
        LeanTween.move(this.gameObject, hitPoint, timeNeededToReach);
        Destroy(this.gameObject, timeNeededToReach + 0.01f);
    }
}
