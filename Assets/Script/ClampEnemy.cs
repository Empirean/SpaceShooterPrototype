using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public class ClampEnemy : MonoBehaviour
{
    float screenWidth;
    float screenHeight;
    Unit unit;

    public float heightPad;
    public float widthPad;

    void Start()
    {
        screenWidth = Utility.screenWidth + widthPad;
        screenHeight = Utility.screenHeight + heightPad;

        unit = GetComponent<Unit>();
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
