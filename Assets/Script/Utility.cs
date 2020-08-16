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

    // Spawn
    public static float waveDelay;
    public static float layerDelay;

    // Key Values
    public static string key_PlayerHealth;
    public static string key_TurretLevel;
    public static string key_MissleLevel;
    public static string key_OrbiterLevel;
    public static string key_CurrentLevel;
    public static string key_RetryCount;

    // Damage Tag
    public static string tagPlayer;
    public static string tagEnemy;

    // Damage vs Armor
    public static float dmg_normalVNormal;
    public static float dmg_normalVMedium;
    public static float dmg_normalVHeavy;
    public static float dmg_pierceVNormal;
    public static float dmg_pierceVMedium;
    public static float dmg_pierceVHeavy;
    public static float dmg_heavyVNormal;
    public static float dmg_heavyVMedium;
    public static float dmg_heavyVHeavy;

    // Special Effects
    public static float vfx_effectDuration;
    public static GameObject vfx_explosionBig;
    public static GameObject vfx_explosionSmall;
    public static GameObject vfx_hitNormal;
    public static GameObject vfx_hitPiercing;
    public static GameObject vfx_hitheavy;

    // Enemy Types
    public static Unit únit_breakerType;
    public static Unit unit_chaserType;
    public static Unit unit_defenderType;
    public static Unit unit_dividerType;
    public static Unit unit_emitterType;
    public static Unit unit_pingerType;
    public static Unit unit_pulserType;
    public static Unit unit_trailerType;
    public static Unit unit_vexerType;

    // Boss Types
    public static Unit boss_argusType;
    public static Unit boss_centaurType;
    public static Unit boss_cerberusType;
    public static Unit boss_cyclopsType;
    public static Unit boss_demigodType;
    public static Unit boss_gorgonType;
    public static Unit boss_harpyType;
    public static Unit boss_hydraType;
    public static Unit boss_manticoreType;
    public static Unit boss_minotaurType;
    
    static Utility()
    {
        // Camera
        cam = Camera.main;
        screenHeight = cam.orthographicSize;
        screenWidth = (cam.aspect * (screenHeight * 2f)) / 2;

        // Collision
        collisionDamageDelay = 1;

        // Spawn
        waveDelay = 1.5f;
        layerDelay = 1f;

        // Key value
        key_PlayerHealth = "PlayerHealth";
        key_TurretLevel = "TurretLevel";
        key_MissleLevel = "MissleLevel";
        key_OrbiterLevel = "OrbiterLevel";
        key_CurrentLevel = "CurrentLevel";
        key_RetryCount = "RetryCount";

        // Damage tag
        tagEnemy = "Enemy";
        tagPlayer = "Player";

        // Damage v Armor
        dmg_normalVNormal = 1f;
        dmg_normalVMedium = .5f;
        dmg_normalVHeavy = .3f;
        dmg_pierceVNormal = .3f;
        dmg_pierceVMedium = 1f;
        dmg_pierceVHeavy = .5f;
        dmg_heavyVNormal = .5f;
        dmg_heavyVMedium = .3f;
        dmg_heavyVHeavy = 1f;
        
        // Special Effects
        vfx_effectDuration = 1f;
        vfx_explosionBig = Resources.Load<GameObject>("Prefab/Effects/ExplosionBig");
        vfx_explosionSmall = Resources.Load<GameObject>("Prefab/Effects/ExplosionSmall");
        vfx_hitNormal = Resources.Load<GameObject>("Prefab/Effects/NormalHit");
        vfx_hitPiercing = Resources.Load<GameObject>("Prefab/Effects/PiercingHit");
        vfx_hitheavy = Resources.Load<GameObject>("Prefab/Effects/HeavyHit");

        // Enemy Types
        únit_breakerType  = Resources.Load<Unit>("Prefab/EnemyTypes/Breaker");
        unit_chaserType = Resources.Load<Unit>("Prefab/EnemyTypes/Chaser");
        unit_defenderType = Resources.Load<Unit>("Prefab/EnemyTypes/Defender");
        unit_dividerType = Resources.Load<Unit>("Prefab/EnemyTypes/Divider");
        unit_emitterType = Resources.Load<Unit>("Prefab/EnemyTypes/Emitter");
        unit_pingerType = Resources.Load<Unit>("Prefab/EnemyTypes/Pinger");
        unit_pulserType = Resources.Load<Unit>("Prefab/EnemyTypes/Pulser");
        unit_trailerType = Resources.Load<Unit>("Prefab/EnemyTypes/Trailer");
        unit_vexerType = Resources.Load<Unit>("Prefab/EnemyTypes/Vexer");

        // Boss Types
        boss_argusType = Resources.Load<Unit>("Prefab/Bosses/Argus");
        boss_centaurType = Resources.Load<Unit>("Prefab/Bosses/Centaur");
        boss_cerberusType = Resources.Load<Unit>("Prefab/Bosses/Cerberus");
        boss_cyclopsType = Resources.Load<Unit>("Prefab/Bosses/Cyclops");
        boss_demigodType = Resources.Load<Unit>("Prefab/Bosses/Demigod");
        boss_gorgonType = Resources.Load<Unit>("Prefab/Bosses/Gorgon");
        boss_harpyType = Resources.Load<Unit>("Prefab/Bosses/Harpy");
        boss_hydraType = Resources.Load<Unit>("Prefab/Bosses/Hydra");
        boss_manticoreType = Resources.Load<Unit>("Prefab/Bosses/Manticore");
        boss_minotaurType = Resources.Load<Unit>("Prefab/Bosses/Minotaur");
    }
}
