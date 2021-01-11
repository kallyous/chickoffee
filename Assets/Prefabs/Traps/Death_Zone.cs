using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Zone : MonoBehaviour
{
    // Interno do Unity, dispara quando algo colide com um IsTrigger.
	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		Player player = hitInfo.GetComponent<Player>();
		Enemy enemy = hitInfo.GetComponent<Enemy>();
		if (player != null)
		{
			player.currentHealth = 0;
			player.Die();
		}
		if (enemy != null)
		{
			enemy.currentHealth = 0;
			enemy.Die();
		}
	}
}
