using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float upForce = 200f;
    public bool isDead = false;
    public float shootRate = 2f;
    public float xFB = 1.35f;
    public float yFB = -0.4f;
    public GameObject fireball;
    private float timeSinceLastShot = 0;
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
        timeSinceLastShot += Time.deltaTime;
        if(isDead) return;
        if(Input.GetMouseButtonDown(0) && !PauseMenu.GameIsPaused){
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0,upForce));
            animator.SetTrigger("Fly");
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            OnShoot();
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
        if(!GameControl.Instance.isGameOver && timeSinceLastShot >= shootRate){
            timeSinceLastShot = 0;
            Vector3 addPos = new Vector3(xFB,yFB,0) + gameObject.transform.position;
            Instantiate(fireball,addPos,Quaternion.identity);
        }
    }
}
