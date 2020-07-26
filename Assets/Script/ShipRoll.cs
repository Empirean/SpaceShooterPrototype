using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRoll : MonoBehaviour
{

    public float maxRotation;
    public float turnSpeed;

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0f, Mathf.Lerp(0, -Input.GetAxis("Horizontal") * maxRotation, Time.deltaTime * turnSpeed), 0f);
    }
}
