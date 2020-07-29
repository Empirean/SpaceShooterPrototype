﻿using System.Collections;
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
    public bool isDestructible = true;

    [Space]
    [Header("Collision")]
    public string damageTag;
    public float collisionDamage;

    protected bool isDead = false;

    float damageCounter;
    bool isBoss = false;
    Color originalColor;

    private void Start()
    {
        if (healthBar == null)
        {
            healthBar = GameObject.Find("BossCurrentHealth").GetComponent<Image>();
            isBoss = true;
        }

        originalColor = healthBar.color;
        currentHealth = maxHealth;
    }

    private void Update()
    {

        healthBar.fillAmount = (float) currentHealth / maxHealth;

        if (healthBar.fillAmount >= 0.7f)
            healthBar.color = Color.green;
        else if (healthBar.fillAmount >= 0.30f && healthBar.fillAmount < 0.7f)
            healthBar.color = Color.yellow;
        else if (healthBar.fillAmount < 0.30f)
            healthBar.color = Color.red; 


        if (currentHealth <= 0.0f && !isDead)
        {
            isDead = true;
            OnDeath();
        }
    }

    public void Damage(float in_damage)
    {
        if (isDestructible) currentHealth -= in_damage;
    }

    public void Heal(float in_health)
    {
        currentHealth = Mathf.Clamp(currentHealth + in_health, 0, maxHealth);
    }

    public void SetHealth(float in_curHealth, float in_maxHealth)
    {
        currentHealth = in_curHealth;
        maxHealth = in_maxHealth;
    }

    private void OnDeath()
    {
        if (isBoss)
        {
            if (OnBossDeath != null)
            {
                OnBossDeath();
            }
        }
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
