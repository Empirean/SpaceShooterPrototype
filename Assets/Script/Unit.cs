using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public Image healthBar;

    public float maxHealth = 10;
    public float speed = 5;
    public float armor = 0;
    public float currentHealth;
    // public string 

    protected bool isDead = false;


    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {

        healthBar.fillAmount = (float)currentHealth / maxHealth;

        if (currentHealth <= 0.0f && !isDead)
        {
            isDead = true;
            OnDeath();
        }
    }

    public void Damage(float in_damage)
    {
        currentHealth -= in_damage;
    }

    public void Heal(float in_health)
    {
        currentHealth = in_health;
    }

    public void SetHealth(float in_curHealth, float in_maxHealth)
    {
        currentHealth = in_curHealth;
        maxHealth = in_maxHealth;
    }

    private void OnDeath()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

}
