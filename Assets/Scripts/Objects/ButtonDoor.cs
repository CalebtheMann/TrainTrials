using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ButtonDoor : MonoBehaviour
{
    public ButtonBehavior Button;
    bool rise = false;
    Vector2 startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Button.Pressed)
        {
            rise = true;
        }
        else
        {
            rise = false;
        }
        if (rise && transform.position.y < startingPosition.y + 8)
        {
            Vector2 newPosition = transform.position;
            newPosition.y += 1.5f * Time.deltaTime;
            transform.position = new Vector2(newPosition.x, newPosition.y);
        }
        else if (transform.position.y > startingPosition.y)
        {
            Vector2 newPosition = transform.position;
            newPosition.y -= .75f * Time.deltaTime;
            transform.position = new Vector2(newPosition.x, newPosition.y);
        }
    }
}
