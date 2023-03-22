using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10;
    [HideInInspector]
    public float speed;

    

    public GameObject deathEffect;

    public float health = 100;
    public int value = 10;


    private void Start()
    {
        speed = startSpeed;
    }

    // Update is called once per frame
    
    
    public void takeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameObject effect = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        PlayerStats.money += value;
        Destroy(gameObject);
    }

    public void Slow(float pct)
    {
        speed = (startSpeed * (1f - pct));
    }
}
