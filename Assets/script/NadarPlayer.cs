using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NadarPlayer : MonoBehaviour
{
    public float swimSpeed = 5f;
    public float waterDrag = 1f;
    public float buoyancy = 1f;
    public LayerMask waterLayer;

    private bool isSwimming = false;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & waterLayer) != 0)
        {
            isSwimming = true;
            rb.useGravity = false;
            rb.drag = waterDrag;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (((1 << other.gameObject.layer) & waterLayer) != 0)
        {
            isSwimming = false;
            rb.useGravity = true;
            rb.drag = 0f;
            rb.velocity = Vector3.zero;
        }
    }

    private void Update()
    {
        if (isSwimming)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 swimForce = (transform.forward * verticalInput + transform.right * horizontalInput) * swimSpeed;
            rb.AddForce(swimForce, ForceMode.Acceleration);

            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * buoyancy, ForceMode.Acceleration);
            }
        }
        else if (!isSwimming && rb.velocity.y < 0f)
        {
            rb.AddForce(Vector3.down * (rb.mass * Mathf.Abs(Physics.gravity.y)), ForceMode.Force);
        }
    }
}
