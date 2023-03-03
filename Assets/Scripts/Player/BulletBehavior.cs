using System.Collections;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float BulletSpeed;
    public LayerMask GroundMask;
    private Rigidbody2D rb;
    public AudioClip Rip;
    public GameObject Crate;

    /// <summary>
    /// Find the bullet's body and chooses the direction it follows.
    /// </summary>
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        Vector2 direction = transform.right;
        rb.velocity = direction * BulletSpeed;
        StartCoroutine(Waiter());
    }

    /// <summary>
    /// Moves the bullet in the direction it is facing.
    /// </summary>
    void Update()
    {
        float direction = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, direction);
    }

    /// <summary>
    /// Destroys the bullet on contact with certain triggers.
    /// </summary>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "Bouncer")
        {
            AudioSource.PlayClipAtPoint(Rip, transform.position);
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Destroys the bullet on contact with certain objects.
    /// </summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="Enemy" || collision.gameObject.tag =="Destroyer")
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Destroys the bullet after three seconds.
    /// </summary>
    /// <returns></returns>
    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
