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
    public static string keyCurrentLevel;
    public static string keyRetryCount;

    public static GameObject ExplosionBig;
    public static GameObject ExplosionSmall;
    public static GameObject HitNormal;
    public static GameObject HitPiercing;
    public static GameObject Hitheavy;
    
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
        keyCurrentLevel = "CurrentLevel";
        keyRetryCount = "RetryCount";

        ExplosionBig = Resources.Load<GameObject>("Prefab/Effects/ExplosionBig");
        ExplosionSmall = Resources.Load<GameObject>("Prefab/Effects/ExplosionSmall");
        HitNormal = Resources.Load<GameObject>("Prefab/Effects/NormalHit");
        HitPiercing = Resources.Load<GameObject>("Prefab/Effects/PiercingHit");
        Hitheavy = Resources.Load<GameObject>("Prefab/Effects/HeavyHit");

    }
}
