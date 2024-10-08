using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player; 
    [SerializeField] private float smoothSpeed = 0.125f; 
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -10); 
    [SerializeField] private float rotationDamping = 3.0f; 

    private Vector3 currentVelocity = Vector3.zero;

    private void LateUpdate()
    {
        
        Vector3 desiredPosition = player.position + player.rotation * offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, smoothSpeed);

        
        transform.position = smoothedPosition;

      
        Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationDamping);
    }
}
