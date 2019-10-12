using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostScript : MonoBehaviour
{
    private float minFactorX = 0.2f;
    private float minFactorY = 0.2f;
    private Vector2 originalSize = new Vector2(0.7f,0.7f);
    private Vector2 newSizeAfterMin;
    private float effectTime = 6f;
    public bool isTriggered = false;
    private bool firstTrigger = true;
    // Start is called before the first frame update
    void Start()
    {
        newSizeAfterMin = originalSize - new Vector2(minFactorX,minFactorY);
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
            
            if(gameObject.tag == "Coin"){
                //if the object is already triggered don't trigger it again.
                if(!isTriggered){
                    isTriggered = true;
                    GameControl.Instance.Score();
                }
                
            }else if(gameObject.tag =="Mini"){
                //if the object is already triggered don't trigger it again.
                if(!isTriggered){
                    isTriggered = true;
                    //minimize the character then wait and resize.
                    StartCoroutine(Minimize(other));
                }
            }
            //hide after contact.
            GetComponent<Renderer>().enabled = false;
        }
    }
    private IEnumerator Minimize(Collider2D other){
        if(firstTrigger && other.transform.localScale.magnitude != originalSize.magnitude){
            firstTrigger = false;
            originalSize = other.transform.localScale;
            minFactorX = originalSize.x/3.5f;
            minFactorY = originalSize.y/3.5f;
            newSizeAfterMin = originalSize - new Vector2(minFactorX,minFactorY);
        }
        //reduce size.
        other.transform.localScale = newSizeAfterMin;

        //wait effect time seconds.
        yield return new WaitForSeconds(effectTime);
        //resize to normal.
        other.transform.localScale = originalSize;
    }
}