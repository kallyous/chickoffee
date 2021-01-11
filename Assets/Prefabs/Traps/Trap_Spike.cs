using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Spike : MonoBehaviour
{
    public int damage = 1;
	public AudioPlayer hitSound;

	// Interno do Unity, dispara quando algo colide com um IsTrigger.
	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		Player player = hitInfo.GetComponent<Player>();
		if (player != null)
		{
			hitSound.Play();
			player.TakeDamage(damage);
		}
	}
}
