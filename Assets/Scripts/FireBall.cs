using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private float fireBallSpeed = 0;
    private bool appear = true;
    private float lifespan = 1.3f;
    private float timeAlive = 0;
    private Animator animator;
    private Rigidbody2D rigidBody2D;
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //initialize fireBallSpeed
        fireBallSpeed = -5f * GameControl.Instance.scrollSpeed;
        rigidBody2D.velocity = new Vector2(fireBallSpeed,0);
    }

    
    void Update()
    {
        timeAlive += Time.deltaTime;
        if(GameControl.Instance.isGameOver || !appear || timeAlive >= lifespan){
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Column"){
            appear = false;
        }else if(other.tag == "Enemy"){
            appear = false;
            GameControl.Instance.Score();
        }
    }
}
