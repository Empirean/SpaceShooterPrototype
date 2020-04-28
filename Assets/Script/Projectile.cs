using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    float speed = 7;
    float damage = 1;

    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    void Start()
    {
        Destroy(gameObject, 8);
    }

    void Update()
    {
        Move();
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void Move()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Unit unit = other.GetComponent<Unit>();
            unit.Damage(1);
        }
    }
}
