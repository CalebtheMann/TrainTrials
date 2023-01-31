using UnityEngine;
using UnityEngine.Windows;

public class PlayerBehavior : MonoBehaviour
{
    public float Speed;
    public float Jump;
    public float DiveSpeed;
    public float SlowDown;
    public LayerMask GroundMask;
    public LayerMask GirderMask;
    public LayerMask DespairMask;
    bool ableToMove = true;
    public bool Left = false;
    public bool DespairMode = false;
    bool jumping = false;
    bool canJump = true;
    bool hitWall = false;
    bool rollTime = false;
    bool playBonk = false;
    bool onGround = false;
    bool touchingGround = false;
    public AudioClip Bonk;
    public AudioClip Whistle;
    public AudioSource AudioSauce;
    public GameObject Screen;
    public GameObject Despair;
    public Sprite Ball;
    Rigidbody2D rb;
    SpriteRenderer sr;
    GameController controller;
    TextKeeper textUpdate;
    public bool Gun = false;
    GameObject gunArm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = rb.GetComponent<SpriteRenderer>();
        controller = GameObject.Find("GameController").GetComponent<GameController>();
        textUpdate = GameObject.Find("CameraController").GetComponent<TextKeeper>();
        Despair = GameObject.Find("Despair");
        gunArm = GameObject.Find("Gun");
        AudioSauce = GetComponent<AudioSource>();
        CarStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (touchingGround)
        {
            onGround = Physics2D.BoxCast(transform.position, new Vector2(.5f, .2f), 0, Vector2.down, 1, GroundMask);
        }
        else
        {
            onGround = false;
        }
        if (rb.velocity.x > 0)
        {
            GetComponent<Animator>().SetBool("Falling", false);
        }
        else if (rb.velocity.x < 0)
        {
            GetComponent<Animator>().SetBool("Falling", true);
        }
        //Checks which direction you should be facing
        if (Left)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
        //BONK
        if (playBonk && hitWall)
        {
            AudioSource.PlayClipAtPoint(Bonk, Camera.main.transform.position);
            playBonk = false;
        }
        //Checks if you should be rolling, then makes you roll.
        if (rollTime)
        {
            if (Left)
            {
                transform.Rotate(0, 0, -360 * Time.deltaTime);
            }
            else
            {
                transform.Rotate(0, 0, 360 * Time.deltaTime);
            }
        }
        //Re-enables movement if you have just dove
        if (onGround)
        {
            GetComponent<Animator>().SetBool("Grounded", true);
            playBonk = false;
            if (rollTime)
            {
                rollTime = false;
            }
            ableToMove = true;
            CancelInvoke("StopDiving");
            transform.eulerAngles = Vector3.forward * 0;
        }
        else
        {
            GetComponent<Animator>().SetBool("Grounded", false);
        }

        //Movement
        if (ableToMove)
        {
            //Jump, jump, jump, jump
            if (ControllerTest.instance.YMove != 0 && onGround && canJump)
            {
                jumping = true;
                canJump = false;
                GetComponent<Animator>().SetTrigger("Jumping");
            }
            if (ControllerTest.instance.DiveMove != 0)
            {
                if (onGround)
                {
                    //Ducking movement would happen here
                }
                else
                {
                //mid-air diving
                    ableToMove = false;
                    playBonk = true;
                    if (!Left)
                    {
                        rb.AddRelativeForce(transform.right * DiveSpeed * 1);
                        transform.eulerAngles = Vector3.forward * -90;
                    }
                    else
                    {
                        rb.AddRelativeForce(transform.right * DiveSpeed * -1);
                        transform.eulerAngles = Vector3.forward * 90;
                    }
                 Invoke("stopdiving", 4);
                }
            }
        }
        else
        {
    //cancel dive
        if (Gun && !rollTime)
            {
                playBonk = false;
                rb.velocity /= 2;
                StopDiving();
            }
            //Bonking 
            if (Left && touchingGround)
            {
                hitWall = Physics2D.Raycast(transform.position, Vector2.left, 1f, GroundMask);

               if (hitWall)
                {
                    CancelInvoke("StopDiving");
                    rb.AddRelativeForce(transform.right * DiveSpeed / -4);
                    transform.eulerAngles = Vector3.forward * -90;
                    rollTime = true;
                    GetComponent<Animator>().SetTrigger("Bonked");
                    Invoke("StopDiving", 5);
                }
            }
            else if (touchingGround)
            {
                hitWall = Physics2D.Raycast(transform.position, Vector2.right, 1f, GroundMask);

                if (hitWall)
                {
                    CancelInvoke("StopDiving");
                    rb.AddRelativeForce(transform.right * DiveSpeed / 4);
                    transform.eulerAngles = Vector3.forward * 90;
                    rollTime = true;
                    GetComponent<Animator>().SetTrigger("Bonked");
                    Invoke("StopDiving", 5);
                }
            }
            else
            {

            }
        }
    }
    void FixedUpdate()
    {
        if (rb.velocity.x > 25)
        {
            rb.velocity = new Vector2 (rb.velocity.x - 1, rb.velocity.y);
        }
        if (rb.velocity.x < -25)
        {
            rb.velocity = new Vector2(rb.velocity.x + 1, rb.velocity.y);
        }
        //Movement
        if (ableToMove)
        {
        if (ControllerTest.instance.XMove > 0 && ControllerTest.instance.XMove < 0)
        {

        }
        //Move right
        else if (ControllerTest.instance.XMove > 0 && rb.velocity.x < 15)
        {
            GetComponent<Animator>().SetBool("Walking", true);
            Left = false;
            rb.AddRelativeForce(transform.right * Speed);
            if (rb.velocity.x < 3)
            {
                rb.AddRelativeForce(transform.right * Speed);
            }
        }
        //Move left
        else if (ControllerTest.instance.XMove < 0 && rb.velocity.x > -15)
        {
            GetComponent<Animator>().SetBool("Walking", true);
            Left = true;
            rb.AddRelativeForce(transform.right * -Speed);
            if (rb.velocity.x > -3)
            {
                rb.AddRelativeForce(transform.right * -Speed);
            }
        }
        else
        {
            Vector3 slowing = rb.velocity;
            slowing.x /= SlowDown;
            rb.velocity = slowing;
            Invoke("StopTalking", 0.5f);
        }
        //Jumping action
        if (jumping)
        {
            rb.AddForce(transform.up * Jump);

            if (rb.velocity.y > Jump)
            {
                rb.velocity = rb.velocity.normalized * Jump;
            }
            jumping = false;
            Invoke("StopJumping", 0.105f);
        }
    }
    }
    void StopDiving()
    {
        if(!ableToMove)
        {
            ableToMove = true;
            transform.eulerAngles = Vector3.forward * 0;
        }

    }
    void StopTalking()
    {
        if (Mathf.Abs(rb.velocity.x) < 3)
        {
            GetComponent<Animator>().SetBool("Walking", false);
        }
    }

    void StopJumping()
    {
        canJump = true;
    }
    void WhistlingAlong()
    {
        AudioSource.PlayClipAtPoint(Whistle, Camera.main.transform.position, 0.15f);
    }
    void CarStart()
    {
        textUpdate.DeathScreenDeath();
        Screen.GetComponent<Animator>().SetBool("Blacked Out", false);
        textUpdate.TimerReset();
        gunArm.SetActive(false);
        //AudioSource.PlayClipAtPoint(Whistle, Camera.main.transform.position);
        //AudioSauce.PlayOneShot(Whistle);
        Invoke("WhistlingAlong", 0.01f);
        Invoke("WhistlingAlong", 0.51f);
        switch (controller.CurrentCar)
        {
            case 0:
                Gun = false;
                GetComponent<Animator>().SetBool("Gunless", true);
                transform.position = new Vector2(216, -2);
                //transform.position = new Vector2(370, -2);
                //transform.position = new Vector2(424, -2);
                //transform.position = new Vector2(494, -2);
                break;
            case 1:
                Gun = false;
                GetComponent<Animator>().SetBool("Gunless", true);
                transform.position = new Vector2(292, -2);
                break;
            case 2:
                Gun = false;
                GetComponent<Animator>().SetBool("Gunless", true);
                transform.position = new Vector2(370, -2);
                break;
            case 3:
                Gun = true;
                GetComponent<Animator>().SetBool("Gunless", false);
                transform.position = new Vector2(424, -2);
                break;
            case 4:
                Gun = true;
                GetComponent<Animator>().SetBool("Gunless", false);
                transform.position = new Vector2(494, -2);
                break;
            case 5:
                Gun = false;
                GetComponent<Animator>().SetBool("Gunless", true);
                transform.position = new Vector2(0, -2);
                break;
            case 6:
                Gun = true;
                GetComponent<Animator>().SetBool("Gunless", false);
                transform.position = new Vector2(72, -2);
                break;
            default:
                Gun = true;
                GetComponent<Animator>().SetBool("Gunless", false);
                transform.position = new Vector2(72, -2);
                break;

        }
        
        this.enabled = true;
    }

    void ScreenDeath()
    {
        Screen.GetComponent<Animator>().SetBool("Blacked Out", true);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GetComponent<Animator>().SetTrigger("Damaged");
            Invoke("ScreenDeath", 1);
            textUpdate.Invoke("DeathScreen", 1);
            rb.velocity = Vector2.zero;
            this.enabled = false;
        }
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Destroyer" || collision.gameObject.tag == "Girder")
        {
            touchingGround = true;
        }
        else
        {
            touchingGround = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Takes you to the next car
        if (collision.tag == "Finish")
        {
            ScreenDeath();
            if (controller.Segmented)
            {
                controller.Invoke("BackToMenu", 1);
            }
            else
            {
                Invoke("CarStart", 1);
            }
            controller.CurrentCar = controller.CurrentCar + 1;
            print(controller.CurrentCar);
            textUpdate.LevelUpdate();
            textUpdate.BestTime();
            rb.velocity = Vector2.zero;
            this.enabled = false;
        }
        if (collision.tag == "GunGiving")
        {
            Gun = true;
            GetComponent<Animator>().SetBool("Gunless", false);
        }
        if (collision.tag == "The End")
        {
            ScreenDeath();
            controller.CurrentCar = controller.CurrentCar + 1;
            print(controller.CurrentCar);
            textUpdate.LevelUpdate();
            textUpdate.BestTime();
            rb.velocity = Vector2.zero;
            this.enabled = false;
            textUpdate.BestTime();
            controller.Invoke("Ending", 1);
        }
    }

}