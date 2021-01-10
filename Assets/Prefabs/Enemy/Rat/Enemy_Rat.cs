using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Rat : MonoBehaviour
{
    Enemy self;
    Animator animator;

    public float attackRange = 1f;

    // Start is called before the first frame update
    void Start()
    {
        self = transform.parent.gameObject.GetComponent<Enemy>();
        animator = transform.parent.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
