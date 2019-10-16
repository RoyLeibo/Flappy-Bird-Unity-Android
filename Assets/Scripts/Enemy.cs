﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;
    private Vector3 force = new Vector3(0,0.2f,0);
    private float moveRate = 0.1f;
    private float currentMoveTime = 0;
    public bool isDead = false;
    private float maxYPos =2.5f;
    private float minYPos = -2f; 
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(GameControl.Instance.isGameOver){
            force = Vector3.zero;
        }
        currentMoveTime += Time.deltaTime;
        if(!isDead){
            if(transform.position.y >= maxYPos || transform.position.y <= minYPos){
                force = -force;
            }
            if(currentMoveTime>=moveRate){
                currentMoveTime = 0;
                AddForce();
                anim.SetTrigger("Fly");
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "EnergyBall"){
            //"kill" the enemy
            isDead = true;
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }
    private void AddForce(){
        transform.position += force;
    }
}
