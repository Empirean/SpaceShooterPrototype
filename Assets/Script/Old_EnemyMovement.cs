using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Unit))]
public class Old_EnemyMovement : MonoBehaviour
{
    public enum Directions
    {
        up,
        down,
        left,
        right,
        none
    }

    public Unit unit;

    float screenHalfheight;

    void Start()
    {
        unit = GetComponent<Unit>();
    }

    public void Move(Vector3 velocity)
    {
        transform.Translate(velocity * Time.deltaTime);
    }

    public Vector3 MoveToDirection(Directions in_direction)
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
