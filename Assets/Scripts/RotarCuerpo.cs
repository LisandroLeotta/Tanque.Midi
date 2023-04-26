using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarCuerpo : MonoBehaviour
{
    [SerializeField] private float torque;
    [SerializeField] private float speed = 0.01f;
    [SerializeField] private float timeCount = 0f;

    Quaternion rotation;

    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, timeCount * speed);
            timeCount += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            rotation = Quaternion.Euler(0, torque, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, timeCount * speed);
            timeCount += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rotation = Quaternion.Euler(0, -torque, 0);
        }

    }


}