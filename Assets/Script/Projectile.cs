using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    float speed = 7;
    float damage = 1;
    float maxRange = 10;
    float currentRange = 0;
    string damageTag = "Enemy";

    void FixedUpdate()
    {
        Move();
        if (!CheckRange()) Destroy(gameObject);
    }

    public void SetSpeed(float in_speed)
    {
        speed = in_speed;
    }

    public void SetDamage(float in_damage)
    {
        damage = in_damage;
    }

    public void SetMaxRange(float in_range)
    {
        maxRange = in_range;
    }

    public void SetDamageTag(string in_damageTag)
    {
        damageTag = in_damageTag;
        
    }

    void Move()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    bool CheckRange()
    {
        if (currentRange < maxRange)
        {
            currentRange = currentRange + (speed * Time.deltaTime);
            return true;
        }
        return false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == damageTag)
        {
            Destroy(gameObject);
            Unit unit = other.GetComponent<Unit>();
            unit.Damage(damage);
        }
    }
}
