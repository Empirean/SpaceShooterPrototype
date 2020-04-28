using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public float maxHealth = 10;
    protected float health = 10;
    protected float speed = 5;
    protected float armor = 0;
    protected bool isDead = false;

    public Image healthBar;

    private void Update()
    {

        healthBar.fillAmount = (float)health / maxHealth;

        if (health <= 0.0f && !isDead)
        {
            isDead = true;
            OnDeath();
        }
    }

    public void Damage(float in_damage)
    {
        health -= in_damage;
    }

    public void Heal(float in_health)
    {
        health = in_health;
    }

    public float GetSpeed()
    {
        return speed;
    }

    private void OnDeath()
    {
        Destroy(gameObject);
    }
    
}
