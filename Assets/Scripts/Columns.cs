using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columns : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Player>() != null)
        {
            if (GameControl.isSingle)
            {
                GameControl.Instance.Score();
            }
            else
            {
                if(other.name.StartsWith("Player1"))
                {
                    MultiGameControl.Instance.Score1();
                }
                else
                {
                    MultiGameControl.Instance.Score2();
                }
            }
        }
    }
}
