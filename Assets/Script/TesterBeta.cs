using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterBeta : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Utility.explosionBig, Vector3.zero, Quaternion.identity);
        }
    }


}
