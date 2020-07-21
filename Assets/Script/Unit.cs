using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Unit : MonoBehaviour
{
    [Header("Health Bar")]
    public Image healthBar;
    public event Action OnBossDeath;

    [Space]
    [Header("Basic Stat")]
    public float maxHealth = 10;
    public float speed = 5;
    public float armor = 0;
    public float currentHealth;

    [Space]
    [Header("Collision")]
    public string damageTag;
    public float collisionDamage;

    protected bool isDead = false;

    float damageCounter;
    bool isBoss = false;

    private void Start()
    {
        if (healthBar == null)
        {
            healthBar = GameObject.Find("BossCurrentHealth").GetComponent<Image>();
            isBoss = true;
        }

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
        if (isBoss) OnBossDeath();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == damageTag)
        {
            Unit unit = other.GetComponent<Unit>();
            unit.Damage(collisionDamage);
            damageCounter = Time.time + Utility.collisionDamageDelay;
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == damageTag && Time.time > damageCounter)
        {
            Unit unit = other.GetComponent<Unit>();
            unit.Damage(collisionDamage);
            damageCounter = Time.time + Utility.collisionDamageDelay;
        }
    }

}
