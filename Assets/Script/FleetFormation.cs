using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FleetFormation : MonoBehaviour
{
    public event Action OnShipDestroyed;
    public int fleetRank;
    public Transform target;
    public float movespeed = 7;
    public float minDistance = 1f;

    Player player;
    float originalDistance;

    void Start()
    {
        player = GetComponent<Player>();
        originalDistance = minDistance;
    }

    void Update()
    {

        if (Vector3.Distance(transform.position, target.position) >= minDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, movespeed * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            minDistance = 0;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            minDistance = originalDistance;
        }

    }

    private void OnDestroy()
    {
        if (OnShipDestroyed != null) OnShipDestroyed();
    }
}
