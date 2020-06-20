using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public class EnemyBehavior : MonoBehaviour
{

    Unit unit;
    Vector3 TargetLocation;
    GameObject player;
    float pauseCounter;


    public float delay;


    public enum BehaviorTypes
    {
        Intercepting,
        Passing,
        Avoiding,
        None
    }

    public BehaviorTypes behaviorType;

    void Start()
    {
        unit = GetComponent<Unit>();
        StartCoroutine("MoveToLocation");
    }


    Vector3 GetPlayerLocation()
    {
        Vector3 v;

        player = GameObject.FindGameObjectWithTag("Player");
        

        if (player == null)
        {
            v = new Vector3(Random.Range(-Utility.screenWidth, Utility.screenWidth), transform.position.y, 0);
        }
        else
        {
            v = new Vector3(player.transform.position.x, transform.position.y, 0);
        }

        return v;
    }

    Vector3 GetRandomLocation()
    {
        return new Vector3(Random.Range(-Utility.screenWidth, Utility.screenWidth), Random.Range(Utility.screenHeight, Utility.screenHeight/2), 0);
    }
    
    IEnumerator MoveToLocation()
    {
        Vector3 targetLocation = GetPlayerLocation();

        while(behaviorType == BehaviorTypes.Intercepting)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetLocation, unit.speed * Time.deltaTime);
            
            if (transform.position == targetLocation)
            {
                targetLocation = GetPlayerLocation();
                yield return new WaitForSeconds(delay);
            }
            
            yield return null;
        }

        while(behaviorType == BehaviorTypes.Passing)
        {
            if (Time.time < pauseCounter || delay == 0)
            {
                transform.Translate((Vector3.down * unit.speed) * Time.deltaTime);
            }
            else
            {
                yield return new WaitForSeconds(delay);
                pauseCounter = Time.time + delay;
                
            }
            
            yield return null;
        }

        targetLocation = GetRandomLocation();

        while (behaviorType == BehaviorTypes.Avoiding)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetLocation, unit.speed * Time.deltaTime);

            if (transform.position == targetLocation)
            {
                targetLocation = GetRandomLocation();
                yield return new WaitForSeconds(delay);
            }

            yield return null;
        }

        StartCoroutine("MoveToLocation");

    }

}
