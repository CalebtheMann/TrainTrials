using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoperBehavior : MonoBehaviour
{
    public bool Cut;
    public GameObject Box;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Cut = true;
            Destroy(gameObject);
            Box.gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
