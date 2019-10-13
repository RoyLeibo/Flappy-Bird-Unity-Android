using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private float fireBallSpeed = 0;
    private bool appear = true;
    private Animator animator;
    private Rigidbody2D rigidBody2D;
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        fireBallSpeed = -1.2f* GameControl.Instance.scrollSpeed;
        rigidBody2D.velocity = new Vector2(fireBallSpeed,0);
    }

    
    void Update()
    {
        if(GameControl.Instance.isGameOver || !appear){
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Column"){
            appear = false;
        }else if(other.tag == "Enemy"){
            appear = false;
            //(Enemy)other.Die();
        }
    }
}
