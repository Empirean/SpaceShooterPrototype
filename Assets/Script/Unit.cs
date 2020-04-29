using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public float maxHealth = 10;
    protected float health = 10;
    public float speed = 5;
    public float armor = 0;
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

    

    private void OnDeath()
    {
        Destroy(gameObject);
    }
    
}
