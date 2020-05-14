﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public class Player : MonoBehaviour
{
    Unit unit;

    void Start()
    {
        unit = GetComponent<Unit>();
    }

    public void Move(Vector3 velocity)
    {
        transform.Translate((velocity * unit.speed) * Time.deltaTime);
    }
}
