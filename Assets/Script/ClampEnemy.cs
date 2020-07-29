using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampEnemy : MonoBehaviour
{
    float screenWidth;
    float screenHeight;

    public float heightPad;
    public float widthPad;

    void Start()
    {
        screenWidth = Utility.screenWidth + widthPad;
        screenHeight = Utility.screenHeight + heightPad;
    }

    void Update()
    {
        Clamp();
    }

    void Clamp()
    {
        if (transform.position.x >= screenWidth || transform.position.x <= -screenWidth ||
            transform.position.y >= screenHeight || transform.position.y <= -screenHeight)
        {
            Destroy(gameObject);
        }

    }
}
