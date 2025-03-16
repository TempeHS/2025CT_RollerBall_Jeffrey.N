using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float SenseX;
    public float SenseY;

    public Transform orientation;

    float RotationX;
    float RotationY;

    private void Start()
    {
        
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("mouseX") * Time.deltaTime * SenseX;
        float mouseY = Input.GetAxisRaw("mouseY") * Time.deltaTime * SenseY;

        RotationY += mouseX;
        RotationX -= mouseY;

        RotationX = Mathf.Clamp(RotationX, -90f, 90f);

        transform.rotation = Quaternion.Euler(RotationX, RotationY, 0f);
        orientation.rotation = Quaternion.Euler(0f, RotationY, 0f);

    }
}
