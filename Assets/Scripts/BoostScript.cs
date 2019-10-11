using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostScript : MonoBehaviour
{
    private float miniSubtractBy = 0.2f;
    private float effectTime = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(GameControl.Instance.isGameOver){
            return;
        }
        if(other.tag == "Player"){
            if(gameObject.name == "Coin"){
                GameControl.Instance.Score();

                //destroy after score is up.
                Destroy(gameObject);
            }else if(gameObject.name == "Mini"){
                //minimize the character then wait and resize.
                StartCoroutine(Minimize(other));
                //TODO: fix the repositioning and respawning.
                gameObject.transform.position += new Vector3(-15f,-25f,0);
            }
        }
        
    }
    private IEnumerator Minimize(Collider2D other){
        
            //reduce size.
            other.transform.localScale -= new Vector3(miniSubtractBy,miniSubtractBy,0);

            //wait effect time seconds.
            //TODO: fix this effect!
            yield return new WaitForSeconds(effectTime);
            //resize to normal.

            other.transform.localScale += new Vector3(miniSubtractBy,miniSubtractBy,0);
            //destroy after coroutine is finished.
            Destroy(gameObject);
    }
    //respawn boost in different locations.
}