using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFunction : MonoBehaviour
{
    public GameObject Bullet;
    public AudioClip Boom;
    AudioSource aSource;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().speed = 0;
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            GetComponent<Animator>().speed = 1;
            aSource.clip = Boom;
            aSource.volume = .25f;
            aSource.Play();
            Invoke("TargetBroken", 0.5f);
        }
    }
    void TargetBroken()
    {
        Destroy(gameObject);
    }
}
