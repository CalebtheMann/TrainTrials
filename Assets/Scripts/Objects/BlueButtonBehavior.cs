using UnityEngine;

public class BlueButtonBehavior : MonoBehaviour
{
    public bool Pressed = false;

    // Update is called once per frame
    void Update()
    {
        if (Pressed)
        {
            GetComponent<Animator>().SetBool("BeingHeldDown", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("BeingHeldDown", false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
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
        else
        {
            Pressed = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
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
    }
    void Unpress()
    {
        GetComponent<Animator>().SetBool("BeingHeldDown", false);
        Pressed = false;
    }
}
