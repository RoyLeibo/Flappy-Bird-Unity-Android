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
        if(gameObject.name == "Coin"){
            GameControl.Instance.Score();
        }else if(gameObject.name == "Mini"){
            Debug.Log("got here");
            //reduce size.
            other.transform.localScale -= new Vector3(miniSubtractBy,miniSubtractBy,0);
            Debug.Log("got");
            //wait effect time seconds.
            //TODO: fix this effect!
            new WaitForSeconds(effectTime);
            //resize to normal.
            other.transform.localScale += new Vector3(miniSubtractBy,miniSubtractBy,0);
        }
        Destroy(gameObject);
    }
}