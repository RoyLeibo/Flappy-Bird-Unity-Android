using System.Collections;
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
    private float minYPos = -2.1f; 
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
            if(currentMoveTime>=moveRate){
                currentMoveTime = 0;
                AddForce();
                anim.SetTrigger("Fly");
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "EnergyBall"){
            if (GameControl.isSingle)
            {
                //"kill" the enemy
                GameControl.Instance.MonsterDead();
            }
            else
            {
                MultiGameControl.Instance.MonsterDead();
            }
            isDead = true;
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }
    private void AddForce(){
        var y = transform.position.y;
        if(((y >= maxYPos || y <= minYPos) && y >-5) ||
        ((y >= maxYPos-16 || y <= minYPos-16)&& y<-10)){
            force = -force;
        }
        transform.position += force;
    }
}
