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
    float behaviorCounter = 0;
    float behaviorSwitchDelay;
    float delay;
    BehaviorTypes currentBehavior;

    public float primaryBehaviorDelay;
    public float secondaryBehaviorDelay;
    public float primaryBehaviorDuration;
    public float secondaryBehaviorDuration;
    
    public bool behaviorSwitch = false;
    public bool permanentSwitch = false;

    public enum BehaviorTypes
    {
        Intercepting,
        Passing,
        Avoiding,
        None,
        Immobile,
        Escaping
    }

    public BehaviorTypes primaryBehavior;
    public BehaviorTypes secondaryBehavior;
    

    void Start()
    {
        behaviorSwitchDelay = Time.time + primaryBehaviorDuration;
        currentBehavior = primaryBehavior;
        delay = primaryBehaviorDelay;

        unit = GetComponent<Unit>();
        StartCoroutine("MoveToLocation");
    }

    void Update()
    {
        if (behaviorSwitch)
        {
            if (Time.time >= behaviorSwitchDelay && behaviorCounter != -1)
            {
                if (behaviorCounter == 0)
                {
                    currentBehavior = secondaryBehavior;
                    behaviorSwitchDelay = Time.time + secondaryBehaviorDuration;
                    delay = secondaryBehaviorDelay;
                    behaviorCounter = 1;

                    if (permanentSwitch)
                    {
                        behaviorCounter = -1;
                    }
                }
                else
                {
                    currentBehavior = primaryBehavior;
                    behaviorSwitchDelay = Time.time + primaryBehaviorDuration;
                    delay = primaryBehaviorDelay;
                    behaviorCounter = 0;
                }
            }
        }
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
            v = new Vector3(player.transform.position.x, Random.Range(Utility.screenHeight, Utility.screenHeight / 2), 0);
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

        while (currentBehavior == BehaviorTypes.None)
        {
            targetLocation = new Vector3(0, Utility.screenHeight / 2,0);
            transform.position = Vector3.MoveTowards(transform.position, targetLocation, unit.speed * Time.deltaTime);

            yield return new WaitForSeconds(delay);
        }

        while (currentBehavior == BehaviorTypes.Intercepting)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetLocation, unit.speed * Time.deltaTime);
            
            if (transform.position == targetLocation)
            {
                targetLocation = GetPlayerLocation();
                yield return new WaitForSeconds(delay);
            }
            
            yield return null;
        }

        while(currentBehavior == BehaviorTypes.Passing)
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

        while (currentBehavior == BehaviorTypes.Avoiding)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetLocation, unit.speed * Time.deltaTime);

            if (transform.position == targetLocation)
            {
                targetLocation = GetRandomLocation();
                yield return new WaitForSeconds(delay);
            }

            yield return null;
        }

        while (currentBehavior == BehaviorTypes.Immobile)
        {
            yield return new WaitForSeconds(delay);

        }

        while (currentBehavior == BehaviorTypes.Escaping)
        {
            if (Time.time < pauseCounter || delay == 0)
            {
                transform.Translate((Vector3.up * unit.speed) * Time.deltaTime);
            }
            else
            {
                yield return new WaitForSeconds(delay);
                pauseCounter = Time.time + delay;

            }

            yield return null;

        }

        StartCoroutine("MoveToLocation");

    }

}
