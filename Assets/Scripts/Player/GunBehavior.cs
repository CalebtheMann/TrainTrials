using UnityEngine;

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
    public AudioClip Shot;

    /// <summary>
    /// Finds the players body
    /// </summary>
    void Start()
    {
        player = GameObject.Find("Eeveeon").GetComponent<PlayerBehavior>();
        sr = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Checks which direction the player is facing, and changes position to compensate.
    /// </summary>
    void Update()
    {
        //Checks which direction you should be facing
        if (player.Left)
        {
            sr.flipY = true;
            Vector2 handChange = transform.position;
            transform.position = new Vector2(player.transform.position.x + 0.225f, player.transform.position.y - .25f);
        }
        else
        {
            sr.flipY = false;
            Vector2 handChange = transform.position;
            transform.position = new Vector2(player.transform.position.x - 0.225f, player.transform.position.y - .25f);
        }
    }

    /// <summary>
    /// Creates the bullet upon firing the gun.
    /// </summary>
    void FixedUpdate()
    {
        //The original gun aiming system
        Vector3 aim = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //The newer gun aiming system
        //float pew = Mathf.Atan2(ControllerTest.instance.AimDirection.y, ControllerTest.instance.AimDirection.x) * Mathf.Rad2Deg;
        float pew = Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, pew);

        if (ControllerTest.instance.GunShot != 0 && canFire == true)
        {
            //Destroys previous bullet
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

    /// <summary>
    /// Gives the gun firing a cooldown.
    /// </summary>
    void shootWait()
    {
        canFire = true;
    }
}
