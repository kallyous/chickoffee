using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            Die();
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

    public void Die()
    {
        print("O pinto foi abatido! T_T");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
