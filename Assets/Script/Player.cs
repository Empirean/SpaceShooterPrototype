using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Unit))]
public class Player : MonoBehaviour
{
    public event Action OnPlayerDeath;

    Unit unit;
    
    void Start()
    {
        unit = GetComponent<Unit>();
    }

    public void Move(Vector3 velocity)
    {
        transform.Translate((velocity * unit.speed) * Time.deltaTime);
    }

    private void OnDestroy()
    {
        if (OnPlayerDeath != null && unit.currentHealth <= 0)
        {
            if (OnPlayerDeath != null) OnPlayerDeath();
        }
    }

}
