using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public bool Pressed = false;
    bool pressing = true;
    public int TimeHeldDown = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Pressed && pressing)
        {
            GetComponent<Animator>().SetTrigger("Pressing");
            Invoke("Unpress", TimeHeldDown);
            pressing = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Pressed = true;
        }
        else if (collision.gameObject.tag == "Player")
        {
            Pressed = true;
        }
        else if (collision.gameObject.tag == "Destroyer")
        {
            Pressed = true;
        }
    }
    void Unpress()
    {
        Pressed = false;
        pressing = true;
    }
}
