using UnityEngine;

public class TriggerButton : MonoBehaviour
{
    public bool Button;
    public bool Pressed;
    public bool Closed;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Button)
        {
            if (collision.gameObject.tag == "Player")
            {
                Pressed = true;
            }
            else if (collision.gameObject.tag == "Destroyer")
            {
                Pressed = true;
            }
            else if (collision.gameObject.tag == "Enemy")
            {
                Pressed = true;
            }
            else if (collision.gameObject.tag == "Bullet")
            {
                Pressed = true;
            }
            else
            {
                Pressed = false;
            }
        }
        else
        {
            if (collision.gameObject.tag == "Player")
            {
                Closed = true;
            }
            else
            {
                Closed = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Button)
        {
            if (collision.gameObject.tag == "Player")
            {
                Pressed = false;
            }
            else if (collision.gameObject.tag == "Destroyer")
            {
                Pressed = false;
            }
            else if (collision.gameObject.tag == "Enemy")
            {
                Pressed = false;
            }
            else if (collision.gameObject.tag == "Bullet")
            {
                Pressed = false;
            }
            else
            {
                Pressed = false;
            }
        }
        else
        {
            if (collision.gameObject.tag == "Player")
            {
                Closed = false;
            }
            else
            {
                Closed = false;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Button)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                Pressed = true;
            }
            
            else
            {
                Pressed = false;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (Button)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                Pressed = false;
            }
        }
    }
}
