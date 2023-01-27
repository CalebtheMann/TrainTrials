using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float BulletSpeed;
    public LayerMask GroundMask;
    private Rigidbody2D rb;
    SpriteRenderer sr;
    public AudioClip Rip;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        Vector2 direction = transform.right;
        rb.velocity = direction * BulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, direction);
    }

    //When the bullets hit the enemy
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "Bouncer")
        {
            AudioSource.PlayClipAtPoint(Rip, transform.position);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="Enemy" || collision.gameObject.tag =="Destroyer")
        {
            Destroy(gameObject);
        }
    }
}
