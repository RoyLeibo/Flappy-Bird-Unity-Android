using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.velocity = new Vector2(GameControl.Instance.scrollSpeed,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameControl.isSingle)
        {
            if (GameControl.Instance.isGameOver)
            {
                rigidBody2D.velocity = Vector2.zero;
            }
        }
        else
        {
            if(MultiGameControl.Instance.isGameOver)
            {
                rigidBody2D.velocity = Vector2.zero;
            }
        }
    }
}
