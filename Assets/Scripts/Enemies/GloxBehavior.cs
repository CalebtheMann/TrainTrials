using UnityEngine;

public class GloxBehavior : MonoBehaviour
{
    public GameObject goxLox;
    Rigidbody2D rb;
    PlayerBehavior player;
    SpriteRenderer sr;
    public AudioClip Chaching;
    public float EnemySpeed;
    public bool XFlipped = true;
    public bool BoxForm = false;

    /// <summary>
    /// Find Glox's body, and finds the player.
    /// </summary>
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = rb.GetComponent<SpriteRenderer>();
        player = GameObject.Find("Eeveeon").GetComponent<PlayerBehavior>();
    }

    /// <summary>
    /// When the box is active, Glox has the box's position.
    /// Otherwise, moves toward the player depending on which direction they are.
    /// </summary>
    void Update()
    {
        if (BoxForm)
        {
            transform.position = goxLox.transform.position;
        }
        else
        {        
            if (player.transform.position.x >= transform.position.x)
            {
                Vector2 newPosition = transform.position;
                newPosition.x += EnemySpeed * Time.deltaTime;
                transform.position = new Vector2(newPosition.x, newPosition.y);
                sr.flipX = false;
                XFlipped = false;
            }
            if (player.transform.position.x <= transform.position.x)
            {
                Vector2 newPosition = transform.position;
                newPosition.x -= EnemySpeed * Time.deltaTime;
                transform.position = new Vector2(newPosition.x, newPosition.y);
                sr.flipX = true;
                XFlipped = true;
            }
        }

    }
    
    /// <summary>
    /// Becomes a box when hit by a bullet.
    /// </summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (BoxForm)
            {
                BoxForm = false;
            }
            else
            {
                rb.velocity = Vector2.zero;
                AudioSource.PlayClipAtPoint(Chaching, Camera.main.transform.position);
                Invoke("RipGox", 0.00001f);
                Invoke("BecomeBox", 0.00002f);
                goxLox.GetComponent<Animator>().SetTrigger("Boxing");
                this.enabled = false;
            }
        }
    }
    
    /// <summary>
    /// Removes Glox from the scene.
    /// </summary>
    void RipGox()
    {
       gameObject.SetActive(false);
    }

    /// <summary>
    /// Activates Box in the scene.
    /// </summary>
    void BecomeBox()
    {
        goxLox.SetActive(true);
        BoxForm = true;
        this.enabled = true;
    }

    /// <summary>
    /// Teleports to Box's position upon loading.
    /// </summary>
    private void OnEnable()
    {
        transform.position = goxLox.transform.position;
        goxLox.GetComponent<GloxBoxBehavior>().SetCanBeHit();
    }
}