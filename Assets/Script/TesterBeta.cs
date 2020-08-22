using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterBeta : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Unit unit = GameObject.FindGameObjectWithTag("Player").GetComponent<Unit>();
            unit.SetHealth(1, 15);

        }

    }


}
