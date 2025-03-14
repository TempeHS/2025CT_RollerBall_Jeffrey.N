using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private int count;

    private float movementX;
    private float movementY;

    public float speed = 0;
    /*public float RotationSpeed = 500f;*/

    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    /*CinemachineFreeLook freeLookCamera;*/
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            winTextObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

        /*RotatePlayer;*/
    }

    /*void RotatePlayer()
    {
        freeLookCamera = yaw.transform.Rotate.eulerAngles.y;

        targetRotation = Quaternion.Euler(0.0f, Camerayaw, 0.0f);

        transform.Rotate = transform.RotateTowards(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
    }*/

    void OnTriggerEnter (Collider other)
    {
        count = count + 1;
        other.gameObject.SetActive(false);

        if(other.gameObject.CompareTag("Pickup"));
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

            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }
    }
    
}
