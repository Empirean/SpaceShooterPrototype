using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Unit))]
public class EnemyMovement : MonoBehaviour
{
    public enum Directions
    {
        up,
        down,
        left,
        right,
        none
    }

    public Directions direction;
    
    Unit unit;
    float screenHalfheight;

    void Start()
    {
        screenHalfheight = Utility.screenHeight / 2;
        unit = GetComponent<Unit>();
    }

    void Update()
    {
        Move(SetVelocity(direction));
    }

    private void Move(Vector3 velocity)
    {
        transform.Translate(velocity * Time.deltaTime);
    }

    private Vector3 SetVelocity(Directions in_direction)
    {
        Vector3 velocity;

        switch (in_direction)
        {
            case Directions.up:
                velocity = new Vector3(0, unit.speed, 0);
                break;
            case Directions.down:
                velocity = new Vector3(0, -unit.speed, 0);
                break;
            case Directions.left:
                velocity = new Vector3(-unit.speed, 0, 0);
                break;
            case Directions.right:
                velocity = new Vector3(unit.speed, 0, 0);
                break;
            default:
                velocity = Vector3.zero;
                break;
        }

        return (velocity);
    }
}
