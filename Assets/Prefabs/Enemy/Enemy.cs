using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 10f;
    public int maxHealth = 3;

    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
    }

    void Die()
    {
        print(gameObject.name + " died.");
        Destroy(gameObject);
    }
}
