using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostScript : MonoBehaviour
{
    private float effectTime = 6f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (GameControl.Instance.isGameOver)
        {
            return;
        }
        if (other.tag == "Player")
        {
            if (gameObject.tag == "Coin")
            {
                //update score.
                if (GameControl.isSingle)
                {
                    GameControl.Instance.coinAudioSource.Play();
                    GameControl.Instance.Score();
                }
                else
                {
                    MultiGameControl.Instance.coinAudioSource.Play();
                    if (other.name.StartsWith("Player1"))
                    {
                        MultiGameControl.Instance.Score1();
                    }
                    else
                    {
                        MultiGameControl.Instance.Score2();
                    }
                }
            }
            else if (gameObject.tag == "Mini")
            {
                if (GameControl.isSingle)
                {
                    GameControl.Instance.miniAudioSource.Play();
                }
                else
                {
                    MultiGameControl.Instance.miniAudioSource.Play();
                }

                //minimize the character then wait and resize.
                StartCoroutine(Minimize(other));
            }
            //hide after contact.
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }
    private IEnumerator Minimize(Collider2D other)
    {
        Vector2 originalSize = other.transform.localScale;
        float minFactorX = originalSize.x / 3.5f;
        float minFactorY = originalSize.y / 3.5f;
        Vector2 newSizeAfterMin = originalSize - new Vector2(minFactorX, minFactorY);
        //reduce size.
        other.transform.localScale = newSizeAfterMin;

        //wait effect time seconds.
        yield return new WaitForSeconds(effectTime);
        //resize to normal.
        other.transform.localScale = originalSize;
    }
}