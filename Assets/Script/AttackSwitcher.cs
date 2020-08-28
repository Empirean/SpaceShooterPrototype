using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSwitcher : MonoBehaviour
{
    public GameObject attack1;
    public GameObject attack2;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            attack1.SetActive(false);
            attack2.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            attack1.SetActive(true);
            attack2.SetActive(false);
        }
    }
}
