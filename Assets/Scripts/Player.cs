using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float upForce = 200f;
    public bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead) return;
        if(Input.GetMouseButtonDown(0) && !PauseMenu.GameIsPaused){
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0,upForce));
            animator.SetTrigger("Fly");
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        isDead = true;
        rb2d.velocity = Vector2.zero;
        animator.SetTrigger("Die");
        GameControl.Instance.Die();
    }
    //activate when shooting key pressed.
    private void OnShoot(){
        //TODO: make the fireball appear with certain shootRate.
    }
}
