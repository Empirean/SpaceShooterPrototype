using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampPlayer : MonoBehaviour
{
    public float heightPad;
    public float widthPad;

    float screenHeight;
    float screenWidth;

    void Start()
    {
        screenWidth = Utility.screenWidth + heightPad;
        screenHeight = Utility.screenHeight + widthPad;
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
