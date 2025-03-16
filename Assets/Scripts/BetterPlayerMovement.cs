using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BetterPlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float MoveSpeed;

    public Transform orientation;

    float HorizontalInput;
    float VerticalInput;

    private int count;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    Vector3 moveDirection;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        countText = 0;
        SetCountText();
        winTextObject.SetActive(false);
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

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 1)
        {
            winTextObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        count = count++;
        other.gameObject.SetActive(false);

        if (other.gameObject.CompareTag("Pickup"))
        {
            SetCountText();
            other.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            winTextObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "YOU LOSE";
        }
    }

}
