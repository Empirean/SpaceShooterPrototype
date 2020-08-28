using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class FleetManager : MonoBehaviour
{
    public List<FleetFormation> formation;
    public Transform spawnPoint;
    public event Action OnGameOver;

    void Start()
    {
        Initialize();
    }

    void OnShipDstroyed()
    {
        SortFleet();
        if (CurrentFleetCount() == 0)
        {
            if (OnGameOver != null) OnGameOver();
        }
    }

    void Initialize()
    {
        for (int i = 0; i < formation.Count; i++)
        {
            FleetFormation t_formation = Instantiate(formation[i], spawnPoint.position, Quaternion.identity) as FleetFormation;
            t_formation.fleetRank = i;

            t_formation.OnShipDestroyed += OnShipDstroyed;
            if (i == 0)
            {
                t_formation.GetComponent<FleetFormation>().enabled = false;
                t_formation.GetComponent<PlayerController>().enabled = true;
            }
            else if (i > 0)
            {
                t_formation.GetComponent<PlayerController>().enabled = false;
                t_formation.GetComponent<FleetFormation>().enabled = true;
            }
        }
        SortFleet();
    }

    

    void SortFleet()
    {
        GameObject[] objectGroup = GameObject.FindGameObjectsWithTag("Player");
        List<FleetFormation> fleetGroup = new List<FleetFormation>();

        foreach (var item in objectGroup)
        {
            fleetGroup.Add(item.GetComponent<FleetFormation>());
        }
        
        int t = 0;
        foreach (var item in fleetGroup.OrderBy(x => x.fleetRank))
        {

            if (t == 0)
            {
                item.GetComponent<PlayerController>().enabled = true;
                item.GetComponent<FleetFormation>().enabled = false;
            }
            else if (t > 0)
            {
                item.GetComponent<PlayerController>().enabled = false;
                item.GetComponent<FleetFormation>().enabled = true;
                item.target = fleetGroup[t - 1].transform;
            }
            t++;
        }
    }

    int CurrentFleetCount()
    {
        GameObject[] g = GameObject.FindGameObjectsWithTag("Player");
        return g.Length;
    }
}
