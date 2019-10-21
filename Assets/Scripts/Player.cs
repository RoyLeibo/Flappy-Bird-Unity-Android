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
    public GameObject energyball;
    private float timeSinceLastShot = 0;
    private Rigidbody2D rb2d;
    private Animator animator;
    public AudioSource audioSource;
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
        if(GameControl.Instance.isGameOver || isDead || PauseMenu.GameIsPaused){
            if(GameControl.Instance.isGameOver && !isDead){
                rb2d.constraints = RigidbodyConstraints2D.FreezePositionY;
            }
            return;
        }
        if(GameControl.isSingle){
            if(gameObject.name.StartsWith("Player1")){
                if(Input.GetKeyDown(KeyCode.UpArrow)){
                    rb2d.velocity = Vector2.zero;
                    rb2d.AddForce(new Vector2(0,upForce));
                    animator.SetTrigger("Fly");
                }
                if(Input.GetKeyDown(KeyCode.RightArrow)){
                    OnShoot();
                }
            }
        }else{
            if(gameObject.name.StartsWith("Player2")){
                if(Input.GetKeyDown(KeyCode.UpArrow)){
                    rb2d.velocity = Vector2.zero;
                    rb2d.AddForce(new Vector2(0,upForce));
                    animator.SetTrigger("Fly");
                }
                if(Input.GetKeyDown(KeyCode.RightArrow)){
                    OnShoot();
                }
            }else if(gameObject.name.StartsWith("Player1")){
                if(Input.GetKeyDown(KeyCode.W)){
                    rb2d.velocity = Vector2.zero;
                    rb2d.AddForce(new Vector2(0,upForce));
                    animator.SetTrigger("Fly");
                }
                if(Input.GetKeyDown(KeyCode.D)){
                    OnShoot();
                }
            }
        }
        
        
        
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        isDead = true;
        rb2d.velocity = Vector2.zero;
        animator.SetTrigger("Die");
        if (GameControl.isSingle)
        {
            GameControl.Instance.Die();
        }
        else
        {
            if (gameObject.name.StartsWith("Player1")) {
                MultiGameControl.Instance.Die(2);
            }
            else
            {
                MultiGameControl.Instance.Die(1);
            }
        }
    }

    //activate when shooting key pressed.
    private void OnShoot(){
        //make the energyball appear with certain shootRate.
        if(!GameControl.Instance.isGameOver && timeSinceLastShot >= shootRate){
            audioSource.Play();
            timeSinceLastShot = 0;
            Vector3 addPos = new Vector3(xFB,yFB,0) + gameObject.transform.position;
            GameObject EBI = (GameObject)Instantiate(energyball,addPos,Quaternion.identity);
            EBI.GetComponent<EnergyBall>().shooter = gameObject;
        }
    }
}
