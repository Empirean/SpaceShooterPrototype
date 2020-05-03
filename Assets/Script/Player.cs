using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Unit))]
[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    PlayerController playerController;
    Unit unit;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        unit = GetComponent<Unit>();
    }

    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized;
        Move(direction);
    }

    void Move(Vector3 direction)
    {
        playerController.Move(direction * unit.speed);
    }
}
