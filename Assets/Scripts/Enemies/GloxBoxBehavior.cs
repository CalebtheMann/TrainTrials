using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloxBoxBehavior : MonoBehaviour
{
    public GameObject gox;
    GloxBehavior goxcode;
    Rigidbody2D rb;
    SpriteRenderer sr;
    public AudioClip Chaching;
    // Start is called before the first frame update
    void Awake()
    {
        goxcode = gox.GetComponent<GloxBehavior>();
        rb = GetComponent<Rigidbody2D>();
        sr = rb.GetComponent<SpriteRenderer>();
        Invoke("Death", .1f);
        if (goxcode.XFlipped)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goxcode.BoxForm)
        {
            
        }
        else
        {
            //transform.position = gox.transform.position;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (goxcode.BoxForm)
            {
                rb.velocity = Vector2.zero;
                AudioSource.PlayClipAtPoint(Chaching, Camera.main.transform.position);
                Invoke("Death", 1);
                Invoke("UnbecomeBox", 1.0001f);
                goxcode.BoxForm = false;
                GetComponent<Animator>().SetTrigger("Unboxing");
            }
            else
            {
                goxcode.BoxForm = true;
            }

        }
    }
    void Death()
    {
        gameObject.SetActive(false);
    }
    void UnbecomeBox()
    {
        gox.SetActive(true);
    }

    private void OnEnable()
    {
        transform.position = gox.transform.position;
    }
}