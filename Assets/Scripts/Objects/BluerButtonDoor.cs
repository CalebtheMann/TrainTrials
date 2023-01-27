using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BluerButtonDoor : MonoBehaviour
{
    public BlueButtonBehavior Button;
    public BlueButtonBehavior Button2;
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
        else if (Button2.Pressed)
        {
            rise = true;
        }
        else
        {
            rise = false;
        }
        if (rise && transform.position.y <= startingPosition.y + 4)
        {
            Vector2 newPosition = transform.position;
            newPosition.y += 5 * Time.deltaTime;
            transform.position = new Vector2(newPosition.x, Mathf.Clamp(newPosition.y, startingPosition.y, startingPosition.y + 4));
        }
        else if (transform.position.y > startingPosition.y)
        {
            Vector2 newPosition = transform.position;
            newPosition.y -= 5 * Time.deltaTime;
            transform.position = new Vector2(newPosition.x, Mathf.Clamp(newPosition.y, startingPosition.y, startingPosition.y + 4));
        }
    }
}