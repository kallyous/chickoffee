using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 20f;
	public int damage = 1;
	public Rigidbody2D rb;

	public float duration = 1f;
	private float dieTime;

	public float harmCooldown = 0.6f;
	private float nextHarm = 0f;
	
	// Use this for initialization
	void Start () {
		rb.velocity = transform.right * speed;
		dieTime = Time.time + duration;
	}

	void Update()
	{
		if (Time.time >= dieTime)
		{
			Destroy(gameObject);
		}
	}

	// Interno do Unity, dispara quando algo colide com um IsTrigger.
	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		if (Time.time >= nextHarm)
		{
			Enemy enemy = hitInfo.GetComponent<Enemy>();
			if (enemy != null)
			{
				enemy.TakeDamage(damage);
				nextHarm = Time.time + harmCooldown;
			}
		}
	}
	
}
