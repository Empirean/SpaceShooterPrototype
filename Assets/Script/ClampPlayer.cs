using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampPlayer : MonoBehaviour
{
    Camera cam;
    float screenHeight;
    float screenWidth;

    void Start()
    {
        cam = Camera.main;
        screenHeight = cam.orthographicSize;
        screenWidth = (cam.aspect * (screenHeight * 2f))/2;
    }

    void Update()
    {
        Clamp();
    }

    void Clamp()
    {
        if (transform.position.x >= screenWidth)
        {
            transform.position = new Vector3(screenWidth, transform.position.y, 0);
        }

        if (transform.position.x <= -screenWidth)
        {
            transform.position = new Vector3(-screenWidth, transform.position.y, 0);
        }

        if (transform.position.y >= screenHeight)
        {
            transform.position = new Vector3(transform.position.x, screenHeight, 0);
        }

        if (transform.position.y <= -screenHeight)
        {
            transform.position = new Vector3(transform.position.x, -screenHeight, 0);
        }
    }
}
