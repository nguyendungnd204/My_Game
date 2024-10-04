using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody myRigidbody;
    private CapsuleCollider myCapsulCollider;

    [SerializeField] private float speed = 50f;
    [SerializeField] private float rotationSpeed = 100f;


    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }
    private void Movement()
    {
        float moveInput = Input.GetAxis("Vertical");
        float rotationInput = Input.GetAxis("Horizontal");
        myRigidbody.MoveRotation(myRigidbody.rotation * Quaternion.Euler(Vector3.up * rotationSpeed * Time.fixedDeltaTime * rotationInput));
        if (moveInput > 0)
        {
            myRigidbody.MovePosition(myRigidbody.position + transform.forward * speed * Time.fixedDeltaTime * moveInput);

        }
    }
    private void FixedUpdate()
    {
       Movement();
    }

}
