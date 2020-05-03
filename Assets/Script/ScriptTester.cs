using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTester : MonoBehaviour
{
    public Unit unit;
    public GameObject[] g;

    private void Start()
    {
        unit = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Unit>();
    }

    private void Update()
    {

    }

}
