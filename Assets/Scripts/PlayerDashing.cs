using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerDashing : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform ThirdPersonCam;
    private BetterPlayerMovement PlayerM;
    private Rigidbody rb;

    [Header("Dashing")]
    public float dashforce;
    public float dashduration;

    [Header("Cooldown")]
    public float dashCD;
    private float dashCDTimer;

    [Header("Input")]
    public KeyCode dashkey = KeyCode.E;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        PlayerM = GetComponent<BetterPlayerMovement>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(dashkey))
        {
            Dash();
        }

        if (dashCDTimer < 0)
            dashCDTimer -= Time.deltaTime;
       
    }

    private void Dash()
    { 
        if (dashCDTimer > 0) return;
        else dashCDTimer = dashCD;

            Vector3 forceToApply = orientation.forward * dashforce;

        rb.AddForce(forceToApply, ForceMode.Impulse);

        Invoke(nameof(DashReset), dashduration);
    }

    private void DashReset()
    {
        
    }
}
