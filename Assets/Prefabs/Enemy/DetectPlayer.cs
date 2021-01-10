using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    Player player;
    Enemy self;
    Animator animator;

    // Setup
    void Start()
    {
        player = null;
        self = transform.parent.gameObject.GetComponent<Enemy>();
        animator = transform.parent.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            self.LookAtPlayer(player.transform);
            animator.SetBool("PlayerWithinRange", true);
        }
    }

    // Interno do Unity, dispara quando algo colide com um IsTrigger.
	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		player = hitInfo.GetComponent<Player>();
	}

    // Interno do Unity, dispara quando algo sai da área de colisão com um IsTrigger.
    void OnTriggerExit2D(Collider2D colInfo)
    {
        player = colInfo.GetComponent<Player>();
        if (player != null)
        {
            player = null;
            animator.SetBool("PlayerWithinRange", false);
        }
    }
}
