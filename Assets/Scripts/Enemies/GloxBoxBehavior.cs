using UnityEngine;

public class GloxBoxBehavior : MonoBehaviour
{
    public GameObject gox;
    GloxBehavior goxcode;
    Rigidbody2D rb;
    SpriteRenderer sr;
    public AudioClip Chaching;
    public bool CanBeHit; 
    /// <summary>
    /// Find Box's body, and disappears upon loading the scene.
    /// </summary>
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

    /// <summary>
    /// Becomes Glox when hit by a bullet.
    /// </summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CanBeHit == true)
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
    }

    /// <summary>
    /// Removes Box from the scene
    /// </summary>
    void Death()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Activates Glox in the scene.
    /// </summary>
    void UnbecomeBox()
    {
        gox.SetActive(true);
    }

    /// <summary>
    /// Teleports to Glox's position upon loading.
    /// </summary>
    private void OnEnable()
    {
        transform.position = gox.transform.position;
    }
    public void SetCanBeHit(){
        CanBeHit = !CanBeHit;
    }
}