using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursue_Player : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    Enemy enemy;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Prepara referências
       player = GameObject.FindGameObjectWithTag("Player").transform;
       rb = animator.GetComponent<Rigidbody2D>();
       enemy = animator.GetComponent<Enemy>();
       // Seta componente pra mover
       enemy.isMoving = true;
       enemy.movingDir = 0f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        /*
        Vector2 target = new Vector2(player.position.x, player.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
        */

        // Atualiza informação sobre posição do jogador
        if (rb.position.x < player.position.x)
        {
            enemy.movingDir = 1f; // Andando para a direita
        }
        else
        {
            enemy.movingDir = -1f; // Andando para a esquerda
        }

        enemy.LookAtPlayer(player);

        if (Vector2.Distance(player.position, rb.position) <= enemy.attackRange)
		{
			animator.SetTrigger("Attack");
		}
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.ResetTrigger("Attack");
       enemy.isMoving = false;
       enemy.movingDir = 0f;
       rb.velocity = new Vector2(0f, rb.velocity.y);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
