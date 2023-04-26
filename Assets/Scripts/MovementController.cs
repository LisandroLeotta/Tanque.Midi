using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [Header("Set Movement")]
    [SerializeField] private float speed = 0f;
    
    [Header("Set Rotation")]
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float turnSmoothVelocity = 0f;

    private Rigidbody rb;
    private Vector3 movementImput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        /*
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
        */
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementImput = new Vector3(horizontal, 0, vertical);

        Rotar(movementImput);
    }

    protected void FixedUpdate()
    {
        Move(movementImput);
    }

    private void Move(Vector3 direction)
    {
        rb.AddForce(direction.normalized * speed, ForceMode.Acceleration);
    }

    private void Rotar(Vector3 rotar)
    {
        float targetAngle = Mathf.Atan2(rotar.x, rotar.z) * Mathf.Rad2Deg;                                                          //Calcula la rotacion segun el movimiento en los ejes.

        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);         //Suabiza la rotacion.

        //transform.rotation = Quaternion.Euler(0f, angle, 0f);
            
    }
}