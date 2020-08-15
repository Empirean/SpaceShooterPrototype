using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Utility
{
    // Camera
    public static Camera cam ;
    public static float screenHeight;
    public static float screenWidth;

    // Collision Damage
    public static float collisionDamageDelay;

    // Key Values
    public static string keyPlayerHealth;
    public static string keyTurretLevel;
    public static string keyMissleLevel;
    public static string keyOrbiterLevel;
    public static string keyCurrentLevel;
    public static string keyRetryCount;

    // Special Effects
    public static float effectDuration;
    public static GameObject explosionBig;
    public static GameObject explosionSmall;
    public static GameObject hitNormal;
    public static GameObject hitPiercing;
    public static GameObject hitheavy;

    // Enemy Types
    public static Unit breakerType;
    public static Unit chaserType;
    public static Unit defenderType;
    public static Unit dividerType;
    public static Unit emitterType;
    public static Unit pingerType;
    public static Unit pulserType;
    public static Unit trailerType;
    public static Unit vexerType;

    // Boss Types
    public static Unit argusType;
    public static Unit centaurType;
    public static Unit cerberusType;
    public static Unit cyclopsType;
    public static Unit demigodType;
    public static Unit gorgonType;
    public static Unit harpyType;
    public static Unit hydraType;
    public static Unit manticoreType;
    public static Unit minotaurType;
    
    static Utility()
    {
        // Camera
        cam = Camera.main;
        screenHeight = cam.orthographicSize;
        screenWidth = (cam.aspect * (screenHeight * 2f)) / 2;

        // Collision
        collisionDamageDelay = 1;

        // Key value
        keyPlayerHealth = "PlayerHealth";
        keyTurretLevel = "TurretLevel";
        keyMissleLevel = "MissleLevel";
        keyOrbiterLevel = "OrbiterLevel";
        keyCurrentLevel = "CurrentLevel";
        keyRetryCount = "RetryCount";

        // Special Effects
        effectDuration = 1f;
        explosionBig = Resources.Load<GameObject>("Prefab/Effects/ExplosionBig");
        explosionSmall = Resources.Load<GameObject>("Prefab/Effects/ExplosionSmall");
        hitNormal = Resources.Load<GameObject>("Prefab/Effects/NormalHit");
        hitPiercing = Resources.Load<GameObject>("Prefab/Effects/PiercingHit");
        hitheavy = Resources.Load<GameObject>("Prefab/Effects/HeavyHit");

        // Enemy Types
        breakerType  = Resources.Load<Unit>("Prefab/EnemyTypes/Breaker");
        chaserType = Resources.Load<Unit>("Prefab/EnemyTypes/Chaser");
        defenderType = Resources.Load<Unit>("Prefab/EnemyTypes/Defender");
        dividerType = Resources.Load<Unit>("Prefab/EnemyTypes/Divider");
        emitterType = Resources.Load<Unit>("Prefab/EnemyTypes/Emitter");
        pingerType = Resources.Load<Unit>("Prefab/EnemyTypes/Pinger");
        pulserType = Resources.Load<Unit>("Prefab/EnemyTypes/Pulser");
        trailerType = Resources.Load<Unit>("Prefab/EnemyTypes/Trailer");
        vexerType = Resources.Load<Unit>("Prefab/EnemyTypes/Vexer");

        // Boss Types
        argusType = Resources.Load<Unit>("Prefab/Bosses/Argus");
        centaurType = Resources.Load<Unit>("Prefab/Bosses/Centaur");
        cerberusType = Resources.Load<Unit>("Prefab/Bosses/Cerberus");
        cyclopsType = Resources.Load<Unit>("Prefab/Bosses/Cyclops");
        demigodType = Resources.Load<Unit>("Prefab/Bosses/Demigod");
        gorgonType = Resources.Load<Unit>("Prefab/Bosses/Gorgon");
        harpyType = Resources.Load<Unit>("Prefab/Bosses/Harpy");
        hydraType = Resources.Load<Unit>("Prefab/Bosses/Hydra");
        manticoreType = Resources.Load<Unit>("Prefab/Bosses/Manticore");
        minotaurType = Resources.Load<Unit>("Prefab/Bosses/Minotaur");
    }
}
