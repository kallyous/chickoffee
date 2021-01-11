using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rbody;
    public float moveSpeed = 10f;
    public float movingDir = 0f; // left -1  right 1
    public bool isMoving = false;

    public int maxHealth = 3;
    private int currentHealth;

    public float attackRange = 1f;
    public bool isFlipped = false;

    public float harmInterval = 0.2f;
    private float nextHarm = 0f;

    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            rbody.velocity = new Vector2(moveSpeed * movingDir, rbody.velocity.y);
        }
    }

	public void LookAtPlayer(Transform player)
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x < player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x > player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}

    public void TakeDamage(int dmg)
    {
        if (Time.time >= nextHarm)
        {
            currentHealth -= dmg;
            nextHarm = Time.time + harmInterval;
            StartCoroutine(DamageAnimation());
        }
    }

    public void Die()
    {
        print(gameObject.name + " died.");
        Destroy(gameObject);
    }

    IEnumerator DamageAnimation()
	{
		SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

		for (int i = 0; i < 2; i++)
		{
			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 0;
				sr.color = c;
			}

			yield return new WaitForSeconds(.02f);

			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 1;
				sr.color = c;
			}

			yield return new WaitForSeconds(.02f);
		}
	}
}
