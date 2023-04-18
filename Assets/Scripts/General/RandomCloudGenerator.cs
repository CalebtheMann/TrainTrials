using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCloudGenerator : MonoBehaviour
{
    public float ScrollSpeed = 3;
    public const float ScrollWidth = 4;
    public GameObject Camera;
    public GameObject Cloud1;
    public GameObject Cloud2;
    public GameObject Cloud3;
    public GameObject Cloud4;
    public int CloudNumber = 1;
    public float StartPos = 14;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        //Getting the current background position
        Vector2 pos = transform.position;

        //Moving the object to the left
        pos.x -= ScrollSpeed * Time.deltaTime;

        //Check if the object is completely off the screen
        /* if (transform.position.x < Camera.transform.position.x - 30)
         {
             pos.x += 30;
         }*/


        //Updating the postion to the new place
        transform.position = pos;
    }

    public virtual void OffScreen(ref Vector2 pos)
    {
        pos.x = Camera.transform.position.x + (3 * ScrollWidth);
        pos.x += 26.9f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 pos = transform.position;
        pos.x = Camera.transform.position.x + (3 * ScrollWidth) + StartPos;
        if (collision.gameObject.tag == "Resetter")
        {
            // CloudNumber = Random.Range(1, 4);
            switch (CloudNumber)
            {
                case (1):
                    Instantiate(Cloud1, pos, Quaternion.identity);
                    break;

                case (2):
                    Instantiate(Cloud2, pos, Quaternion.identity);
                    break;

                case (3):
                    Instantiate(Cloud3, pos, Quaternion.identity);
                    break;

                case (4):
                    Instantiate(Cloud4, pos, Quaternion.identity);
                    break;
            }
            Debug.Log("pls i hate this");
        }
    }
}



