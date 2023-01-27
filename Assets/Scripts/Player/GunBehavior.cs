using UnityEngine;
using UnityEngine.XR;

public class GunBehavior : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject BulletSpawner;
    public GameObject BulletSpawnerLeft;
    bool canFire = true;
    Vector2 bulletPosition;
    GameObject spawnedBullet;
    PlayerBehavior player;
    SpriteRenderer sr;
    GameController controller;
    public AudioClip Shot;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Eeveeon").GetComponent<PlayerBehavior>();
        controller = GameObject.Find("GameController").GetComponent<GameController>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Checks which direction you should be facing
        if (player.Left)
        {
            sr.flipY = true;

            Vector2 handChange = transform.position;
            transform.position = new Vector2(player.transform.position.x + .26f, player.transform.position.y - .3f);
        }
        else
        {
            sr.flipY = false;
            Vector2 handChange = transform.position;
            transform.position = new Vector2(player.transform.position.x - .26f, player.transform.position.y - .3f);
        }
    }

    void FixedUpdate()
    {
        Vector3 aim = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float pew = Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, pew);

        if (Input.GetKey(KeyCode.Mouse0) && canFire == true)
        {
            if(spawnedBullet)
            {
                Destroy(spawnedBullet);
            }
            if (player.Left)
            {
                bulletPosition = BulletSpawnerLeft.transform.position;
            }
            else
            {
                bulletPosition = BulletSpawner.transform.position;
            }

            Vector3 bulletRotation = transform.eulerAngles;
            spawnedBullet = Instantiate(Bullet, bulletPosition, Quaternion.Euler(bulletRotation));
            AudioSource.PlayClipAtPoint(Shot, transform.position);
            canFire = false;
            Invoke("shootWait", 0.5f);
        }
    }
    void shootWait()
    {
        canFire = true;
    }
}
