using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour
{
    public float movementSpeedReduction = .5f;

    Player player;
    Unit unit;

    float originalSpeed;
    float newSpeed;

    void Start()
    {
        player = GetComponent<Player>();
        unit = GetComponent<Unit>();

        originalSpeed = unit.speed;
        newSpeed = originalSpeed - (originalSpeed * movementSpeedReduction);
    }

    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            unit.speed = newSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            unit.speed = originalSpeed;
        }


        player.Move(direction);
    }

}
