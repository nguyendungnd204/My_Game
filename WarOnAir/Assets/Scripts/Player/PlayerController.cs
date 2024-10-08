using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody myRigidbody;
    [SerializeField] public float speed ;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private float tiltAmount = 30f;
    [SerializeField] private float tiltSpeed = 2f;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }
    private void MoveForward()
    {
        Vector3 targetPosition = myRigidbody.position + transform.forward * speed * Time.fixedDeltaTime;
        myRigidbody.MovePosition(Vector3.Lerp(myRigidbody.position, targetPosition, Time.fixedDeltaTime * speed));
    }
    private void Movement()
    {
        // Lấy giá trị nhập từ người chơi
        float rotationInput = Input.GetAxis("Horizontal"); // A/D hoặc mũi tên trái/phải
        // Xoay tàu
        myRigidbody.MoveRotation(myRigidbody.rotation * Quaternion.Euler(Vector3.up * rotationSpeed * Time.fixedDeltaTime * rotationInput));

        // Nghiêng tàu theo trục X khi di chuyển
        float moveInput = Input.GetAxis("Vertical"); // W/S hoặc mũi tên lên/xuống
        float targetTilt = -moveInput * tiltAmount;
        Quaternion targetRotation = Quaternion.Euler(targetTilt, transform.eulerAngles.y, 0f);
        myRigidbody.MoveRotation(Quaternion.Slerp(myRigidbody.rotation, targetRotation, tiltSpeed * Time.fixedDeltaTime));
    }

    private void FixedUpdate()
    {
        Movement();
        MoveForward();
    }
}
