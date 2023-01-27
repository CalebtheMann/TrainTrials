using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    public float ScrollSpeed = 3;
    public const float ScrollWidth = 8;
    public GameObject Camera;
    public int StartingPosition;
    // background width in pixels / pixels per Unit
    private void Start()
    {
        switch (StartingPosition)
            {
                case(1):
                    Vector2 startPos = transform.position;
                    startPos.x = Camera.transform.position.x - 16;
                break;
                case (2):
                    Vector2 startPos2 = transform.position;
                    startPos2.x = Camera.transform.position.x - 8;
                break;
                case (3):
                    Vector2 startPos3 = transform.position;
                    startPos3.x = Camera.transform.position.x + 8;
                break;
                case (4):
                    Vector2 startPos4 = transform.position;
                    startPos4.x = Camera.transform.position.x + 16;
                break;

        }

    }
    void FixedUpdate()
    {
        //Getting the current background position
        Vector2 pos = transform.position;

        //Moving the object to the left
        pos.x -= ScrollSpeed * Time.deltaTime;

        //Check if the object is completely off the screen
        if (transform.position.x < Camera.transform.position.x-18)
        {
            OffScreen(ref pos);
        }

        //Updating the postion to the new place
        transform.position = pos;
    }

    public virtual void OffScreen(ref Vector2 pos)
    {
        //pos.x = Camera.transform.position.x + (3 * ScrollWidth);
        pos.x += 36;
    }
}