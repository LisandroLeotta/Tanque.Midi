using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [Header("Set Movement")]
    [SerializeField] private float speed = 0f;
    
    private Rigidbody rb;
    private Vector3 movementImput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        movementImput = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movementImput.z = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementImput.z = -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movementImput.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementImput.x = 1;
        }
    }

    protected void FixedUpdate()
    {
        Move(movementImput);
    }

    private void Move(Vector3 direction)
    {
        rb.AddForce(direction.normalized * speed, ForceMode.Acceleration);
    }
}
