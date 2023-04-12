using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    public TriggerButton Button;
    public TriggerButton Closer;
    public bool rise = false;
    public bool GloxDoor;
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
            GetComponent<Animator>().SetBool("Activated", true);
        }
        if (rise && Closer.Closed)
        {
            rise = false;
            GetComponent<Animator>().SetBool("Activated", false);
        }

        if (rise && transform.position.y == startingPosition.y + 4)
        {
        
        }
        else if (GloxDoor && rise && transform.position.y <= startingPosition.y + 7)
        {
            Vector2 newPosition = transform.position;
            newPosition.y += 5 * Time.deltaTime;
            transform.position = new Vector2(newPosition.x, Mathf.Clamp(newPosition.y, startingPosition.y, startingPosition.y + 7));
        }
        else if (rise && transform.position.y <= startingPosition.y + 4)
        {
            Vector2 newPosition = transform.position;
            newPosition.y += 5 * Time.deltaTime;
            transform.position = new Vector2(newPosition.x, Mathf.Clamp(newPosition.y, startingPosition.y, startingPosition.y + 4));
        }
        if (!rise && transform.position.y == startingPosition.y)
        {

        }
        else if (!rise && transform.position.y > startingPosition.y)
        {
            Vector2 newPosition = transform.position;
            newPosition.y -= 5 * Time.deltaTime;
            transform.position = new Vector2(newPosition.x, Mathf.Clamp(newPosition.y, startingPosition.y, startingPosition.y + 4));
        }
    }
}

