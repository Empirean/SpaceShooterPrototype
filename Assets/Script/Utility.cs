using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Utility
{

    public static Camera cam ;
    public static float screenHeight;
    public static float screenWidth;
    
    public static float collisionDamageDelay;

    public static string keyPlayerHealth;
    public static string keyTurretLevel;
    public static string keyMissleLevel;
    public static string keyOrbiterLevel;

    static Utility()
    {
        cam = Camera.main;
        screenHeight = cam.orthographicSize;
        screenWidth = (cam.aspect * (screenHeight * 2f)) / 2;

        collisionDamageDelay = 1;

        keyPlayerHealth = "PlayerHealth";
        keyTurretLevel = "TurretLevel";
        keyMissleLevel = "MissleLevel";
        keyOrbiterLevel = "OrbiterLevel";
    }
}
