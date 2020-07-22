﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Utility
{

    public static Camera cam ;
    public static float screenHeight;
    public static float screenWidth;
    
    public static float collisionDamageDelay;

    static Utility()
    {
        cam = Camera.main;
        screenHeight = cam.orthographicSize;
        screenWidth = (cam.aspect * (screenHeight * 2f)) / 2;

        collisionDamageDelay = 1;
    }
}
