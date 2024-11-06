using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    //Track damage taken, if health is 0 then destory monster
    public void TakeDamage(int damage)
    {
            health -= damage;
            if(health <= 0)
            {
                Destroy(gameObject);
            }
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}