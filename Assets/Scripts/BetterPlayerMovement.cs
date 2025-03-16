using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterPlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float MoveSpeed;

    public Transform orientation;

    float HorizontalInput;
    float VerticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        MyInput(); 
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MyInput()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * VerticalInput + orientation.right * HorizontalInput;

        rb.AddForce(moveDirection.normalized * MoveSpeed * 10f, ForceMode.Force);
    }

}
