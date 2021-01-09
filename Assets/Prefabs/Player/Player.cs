using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public float harmInterval = 1f;
    private float nextHarmTime;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        print("Pinto saudável, " + currentHealth + " HP");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            print("O pinto foi abatido! T_T");
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        if (Time.time >= nextHarmTime)
        {
            currentHealth -= damage;
            nextHarmTime = Time.time + harmInterval;
            print("Pinto ferido! " + currentHealth + " HP");
        }
    }
}
