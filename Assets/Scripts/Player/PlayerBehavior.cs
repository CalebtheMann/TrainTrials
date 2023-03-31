using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpStart;
    public float JumpTimer;
    public float JumpTimerMax;
    [SerializeField] float maxJumpHeight;
    [SerializeField] float delay;
    [SerializeField] float diveSpeed;
    public float SlowDown;
    public static PlayerBehavior Instance;
    public LayerMask GroundMask;
    public LayerMask GirderMask;
    bool ableToMove = true;
    public bool Left = false;
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
    public Sprite Ball;
    Rigidbody2D rb;
    SpriteRenderer sr;
    GameController controller;
    TextKeeper textUpdate;
    public bool Gun = false;
    GameObject gunArm;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject); //Without this it restarts with no dive
        rb = GetComponent<Rigidbody2D>();
        sr = rb.GetComponent<SpriteRenderer>();
        controller = GameObject.Find("GameController").GetComponent<GameController>();
        textUpdate = GameObject.Find("CameraController").GetComponent<TextKeeper>();
        gunArm = GameObject.Find("Gun");
        AudioSauce = GetComponent<AudioSource>();
        CarStart();
    }

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
            //Starting a jump
            if (ControllerTest.instance.YMove != 0 && onGround && canJump)
            {
                canJump = false;
                jumping = true;
                rb.AddForce(transform.up * jumpStart, ForceMode2D.Impulse);
                GetComponent<Animator>().SetTrigger("Jumping");
            }
            /*if (ControllerTest.instance.DiveMove != 0)
            {
                if (!onGround)
                {
                //Mid-air diving
                    ableToMove = false;
                    playBonk = true;
                    if (!Left)
                    {
                        rb.AddRelativeForce(transform.right * diveSpeed * 1);
                        transform.eulerAngles = Vector3.forward * -90;
                    }
                    else
                    {
                        rb.AddRelativeForce(transform.right * diveSpeed * -1);
                        transform.eulerAngles = Vector3.forward * 90;
                    }
                 Invoke("StopDiving", 4);
                }
            }*/
        }
        else
        {
        //Cancel dive
            /*if (ControllerTest.instance.DiveMove != 0 && onGround && !canJump && !rollTime)
            {
                playBonk = false;
                rb.velocity /= 2;
                StopDiving();
            }*/
        //Bonking 
            if (Left && touchingGround)
            {
                hitWall = Physics2D.Raycast(transform.position, Vector2.left, 1f, GroundMask);

                if (hitWall)
                {
                    CancelInvoke("StopDiving");
                    rb.AddRelativeForce(transform.right * diveSpeed / -4);
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
                    rb.AddRelativeForce(transform.right * diveSpeed / 4);
                    transform.eulerAngles = Vector3.forward * 90;
                    rollTime = true;
                    GetComponent<Animator>().SetTrigger("Bonked");
                    Invoke("StopDiving", 5);
                }
            }
        }
        //Jumping cont.
        if (ControllerTest.instance.YMove != 0 && jumping)
            {
                rb.AddForce(transform.up * (JumpTimer - delay) * -maxJumpHeight * (JumpTimer + JumpTimerMax));
            }
            else
            {
                canJump = true;
                jumping = false;
            }
    }
    void FixedUpdate()
    {
        if (rb.velocity.x > 25)
        {
            rb.velocity = new Vector2(rb.velocity.x - 1, rb.velocity.y);
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
                rb.AddRelativeForce(transform.right * speed);
                if (rb.velocity.x < 3)
                {
                    rb.AddRelativeForce(transform.right * speed);
                }
            }
            //Move left
            else if (ControllerTest.instance.XMove < 0 && rb.velocity.x > -15)
            {
                GetComponent<Animator>().SetBool("Walking", true);
                Left = true;
                rb.AddRelativeForce(transform.right * -speed);
                if (rb.velocity.x > -3)
                {
                    rb.AddRelativeForce(transform.right * -speed);
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

        }
    }

    /*public void Dive()
    {
        if (ableToMove && !onGround)
        {
                //mid-air diving
            ableToMove = false;
            playBonk = true;
            rb.velocity = Vector3.zero;
            if (!Left)
            {
                rb.AddForce(transform.right * diveSpeed * 1, ForceMode2D.Impulse);
                transform.eulerAngles = Vector3.forward * -90;
            }
            else
            {
                rb.AddRelativeForce(transform.right * diveSpeed * -1, ForceMode2D.Impulse);
                transform.eulerAngles = Vector3.forward * 90;
            }
            Invoke("StopDiving", 4);
        }
    }

    void StopDiving()
    {
        if(true)
        {
            ableToMove = true;
            transform.eulerAngles = Vector3.forward * 0;
        }

    }*/
    
    void StopTalking()
    {
        if (Mathf.Abs(rb.velocity.x) < 3)
        {
            GetComponent<Animator>().SetBool("Walking", false);
        }
    }

    void WhistlingAlong()
    {
        AudioSource.PlayClipAtPoint(Whistle, Camera.main.transform.position, 0.15f);
    }
    void CarStart()
    {
        //textUpdate.DeathScreenDeath();
        Screen.GetComponent<Animator>().SetBool("Blacked Out", false);
        //textUpdate.TimerReset();
        //gunArm.SetActive(false);
        //Invoke("WhistlingAlong", 0.01f);
        //Invoke("WhistlingAlong", 0.51f);
        switch (controller.CurrentCar)
        {
            case 0:
                Gun = true;
                GetComponent<Animator>().SetBool("Gunless", true);
                //transform.position = new Vector2(216, -2);
                //transform.position = new Vector2(370, -2);
                //transform.position = new Vector2(424, -2);
                //transform.position = new Vector2(494, -2);
                break;
            case 1:
                transform.position = new Vector2(292, -2);
                break;
            case 2:
                transform.position = new Vector2(370, -2);
                break;
            case 3:
                transform.position = new Vector2(424, -2);
                break;
            case 4:
                transform.position = new Vector2(494, -2);
                break;
            case 5:
                transform.position = new Vector2(0, -2);
                break;
            case 6:
                transform.position = new Vector2(72, -2);
                break;
            case 7:
                transform.position = new Vector2(31, -1.6f);
                break;
            case 8:
                transform.position = new Vector2(128.14f, -1.64f);
                break;
            case 9:
                transform.position = new Vector2(147.77f, -1.64f);
                break;
            default:
                transform.position = new Vector2(72, -2); //Change this
                break;
                /*default:
                    Gun = true;
                    GetComponent<Animator>().SetBool("Gunless", false);
                    transform.position = new Vector2(72, -2);
                    break;*/

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
            /* Invoke("ScreenDeath", 1);
             textUpdate.Invoke("DeathScreen", 1);
             rb.velocity = Vector2.zero;
             this.enabled = false;*/
            Restart();
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
            //ScreenDeath();
                controller.Invoke("BackToMenu", 1);
            controller.CurrentCar = controller.CurrentCar + 1;
            //print(controller.CurrentCar);
            //textUpdate.BestTime();
            rb.velocity = Vector2.zero;
            this.enabled = false;
        }
        if (collision.tag == "GunGiving")
        {
            Gun = true;
            GetComponent<Animator>().SetBool("Gunless", false);
        }
        if (collision.tag == "FuseStart")
        {
            controller.CurrentCar = 7;
        }

        if (collision.tag == "Checkpoint1")
        {
            controller.CurrentCar = 8;
        }

        if (collision.tag == "Checkpoint2")
        {
            controller.CurrentCar = 9;
        }

        if (collision.tag == "DoorClosing")
        {
            //Add code to close doors
        }
        if (collision.tag == "The End")
        {
            ScreenDeath();
            controller.CurrentCar = controller.CurrentCar + 1;
            print(controller.CurrentCar);
            textUpdate.BestTime();
            rb.velocity = Vector2.zero;
            this.enabled = false;
            textUpdate.BestTime();
            controller.Invoke("Ending", 1);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("FuseScene");
        CarStart();
    }

}