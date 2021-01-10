using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Rat : MonoBehaviour
{
    Enemy self;

    void Start() {
        self = transform.parent.GetComponent<Enemy>();
    }

    // Interno do Unity, dispara quando algo colide com um IsTrigger.
	void OnTriggerEnter2D (Collider2D hitInfo)
	{
        Player player = hitInfo.GetComponent<Player>();
		if (player != null)
        {
            GetComponent<AudioSource>().Play();
            player.TakeDamage(self.damage);
        }
	}
}
