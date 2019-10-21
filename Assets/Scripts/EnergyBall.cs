using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour
{
    private float energyBallSpeed = 0;
    private bool appear = true;
    private float lifespan = 1.3f;
    private float timeAlive = 0;
    private Animator animator;
    private Rigidbody2D rigidBody2D;
    public GameObject shooter;
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //initialize energyBallSpeed
        energyBallSpeed = -5f * GameControl.Instance.scrollSpeed;
        rigidBody2D.velocity = new Vector2(energyBallSpeed,0);
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
            if (GameControl.isSingle)
            {
                GameControl.Instance.Score();
            }
            else
            {
                if (shooter.name.StartsWith("Player1"))
                {
                    MultiGameControl.Instance.Score1();
                }
                else if (shooter.name.StartsWith("Player2"))
                {
                    MultiGameControl.Instance.Score2();
                }
            }
        }
    }
}
