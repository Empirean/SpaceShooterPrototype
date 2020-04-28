using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Utility
{

    public static Camera cam ;
    public static float screenHeight;
    public static float screenWidth;

    static Utility()
    {
        cam = Camera.main;
        screenHeight = cam.orthographicSize;
        screenWidth = (cam.aspect * (screenHeight * 2f)) / 2;

    }
}
