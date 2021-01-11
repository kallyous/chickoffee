using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public HealthBar healthBar;
    public int maxHealth = 10;
    private int currentHealth;

    public float harmInterval = 0.5f;
    private float nextHarmTime;

    public AudioPlayer musicBackground;
    public AudioPlayer musicDefeat;
    public AudioPlayer musicVictory;
    
    Animator animator;

    float deathTime;
    float deathWait = 6f;
    bool dead = false;

    float victoryTime;
    float victoryWait = 5f;
    bool won = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        if (healthBar)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            if (!dead) { Die(); }
            else if (Time.time > deathTime + deathWait)
            {
                SceneManager.LoadScene(0);
            }
        }
        if (won && Time.time > victoryTime + victoryWait) {
            SceneManager.LoadScene(0);
        }
        print("HP " + currentHealth + "/" + maxHealth);
    }

    public void Win()
    {
        won = true;
        animator.SetBool("Victory", true);
        musicBackground.Stop();
        musicVictory.Play();
        victoryTime = Time.time;
    }

    public void TakeDamage(int damage)
    {
        if (Time.time >= nextHarmTime)
        {
            currentHealth -= damage;
            if (healthBar)
            {
                healthBar.SetHealth(currentHealth);
            }
            nextHarmTime = Time.time + harmInterval;
            StartCoroutine(DamageAnimation());
        }
    }

    public void Die()
    {
        dead = true;
        animator.SetBool("Dead", true);
        musicBackground.Stop();
        musicDefeat.Play();
        deathTime = Time.time;
    }

    IEnumerator DamageAnimation()
	{
		SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

		for (int i = 0; i < 5; i++)
		{
			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 0;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);

			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 1;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);
		}
	}
}
