using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Spike : MonoBehaviour
{
    public int damage = 1;

	// Interno do Unity, dispara quando algo colide com um IsTrigger.
	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		Player player = hitInfo.GetComponent<Player>();
		if (player != null)
		{
			player.TakeDamage(damage);
		}
	}
}
