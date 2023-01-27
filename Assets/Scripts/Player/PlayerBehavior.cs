using UnityEngine;

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
    bool despairCooldown = true;
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
    bool g = false;
    bool u = false;
    public bool N = false;

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
        Gun = false;
        g = false;
        u = false;
        N = false;
        CarStart();
    }

    // Update is called once per frame
    void Update()
    {


        Debug.Log(ControllerTest.instance.XMove);
        ////GUN
        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    g = true;
        //}
        //if (Input.GetKeyDown(KeyCode.U) && g)
        //{
        //    u = true;
        //}
        //if (Input.GetKeyDown(KeyCode.N) && u)
        //{
        //    N = true;
        //    gunArm.SetActive(true);
        //}
        //if (gunArm != null && g && u && N)
        //{
        //    controller.UsingGUN();
        //}
        //else if (Gun && gunArm != null)
        //{
        //    gunArm.SetActive(true);
        //}
        //else if (!Gun && gunArm != null)
        //{
        //    gunArm.SetActive(false);
        //}
        //if (touchingGround)
        //{
        //    onGround = Physics2D.BoxCast(transform.position, new Vector2(.5f, .2f), 0, Vector2.down, 1, GroundMask);
        //}
        //else
        //{
        //    onGround = false;
        //}
        //if (rb.velocity.x > 0)
        //{
        //    GetComponent<Animator>().SetBool("Falling", false);
        //}
        //else if (rb.velocity.x < 0)
        //{
        //    GetComponent<Animator>().SetBool("Falling", true);
        //}
        ////Checks which direction you should be facing
        //if (Left)
        //{
        //    sr.flipX = true;
        //}
        //else
        //{
        //    sr.flipX = false;
        //}
        ////BONK
        //if (playBonk && hitWall)
        //{
        //    AudioSource.PlayClipAtPoint(Bonk, Camera.main.transform.position);
        //    playBonk = false;
        //}
        ////Checks if you should be rolling, then makes you roll.
        //if (rollTime)
        //{
        //    if (Left)
        //    {
        //        transform.Rotate(0, 0, -360 * Time.deltaTime);
        //    }
        //    else
        //    {
        //        transform.Rotate(0, 0, 360 * Time.deltaTime);
        //    }
        //}
        ////Re-enables movement if you have just dove
        //if (onGround)
        //{
        //    GetComponent<Animator>().SetBool("Grounded", true);
        //    playBonk = false;
        //    if (rollTime)
        //    {
        //        rollTime = false;
        //    }
        //    ableToMove = true;
        //    CancelInvoke("StopDiving");
        //    transform.eulerAngles = Vector3.forward * 0;
        //}
        //else
        //{
        //    GetComponent<Animator>().SetBool("Grounded", false);
        //    //Despair Mode
        //    DespairMode = Physics2D.Raycast(transform.position, Vector2.up, 1f, DespairMask)/*.transform.gameObject*/;
        //    if (DespairMode && despairCooldown)
        //    {
        //        Vector2 HoldingOn;
        //        HoldingOn.x = Despair.transform.position.x - 2;
        //        HoldingOn.y = Despair.transform.position.y - 3;
        //        transform.position = HoldingOn;
        //        ableToMove = false;
        //        if (Input.GetKeyDown(KeyCode.Space))
        //        {
        //            DespairMode = false;
        //            despairCooldown = false;
        //            Invoke("CoolingOff", 1);
        //        }
        //    }
        //}

        ////Movement
        //if (ableToMove)
        //{
        //    //Jump, jump, jump, jump
        //    if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && onGround && canJump)
        //    {
        //        jumping = true;
        //        canJump = false;
        //        GetComponent<Animator>().SetTrigger("Jumping");
        //    }
        //    if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        //    {
        //        if (onGround)
        //        {
        //            //Ducking movement would happen here
        //        }
        //        else
        //        {
        //            //Mid-air diving
        //            ableToMove = false;
        //            playBonk = true;
        //            if (!Left)
        //            {
        //                rb.AddRelativeForce(transform.right * DiveSpeed * 1);
        //                transform.eulerAngles = Vector3.forward * -90;
        //            }
        //            else
        //            {
        //                rb.AddRelativeForce(transform.right * DiveSpeed * -1);
        //                transform.eulerAngles = Vector3.forward * 90;
        //            }
        //            Invoke("StopDiving", 4);
        //        }
        //    }
        //}
        //else
        //{
        //    //Cancel Dive
        //    if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && !rollTime)
        //    {
        //        playBonk = false;
        //        rb.velocity /= 2;
        //        StopDiving();
        //    }
        //    //Bonking 
        //    if (Left && touchingGround)
        //    {
        //        hitWall = Physics2D.Raycast(transform.position, Vector2.left, 1f, GroundMask);

        //        if (hitWall)
        //        {
        //            CancelInvoke("StopDiving");
        //            rb.AddRelativeForce(transform.right * DiveSpeed / -4);
        //            transform.eulerAngles = Vector3.forward * -90;
        //            rollTime = true;
        //            GetComponent<Animator>().SetTrigger("Bonked");
        //            Invoke("StopDiving", 5);
        //        }
        //    }
        //    else if (touchingGround)
        //    {
        //        hitWall = Physics2D.Raycast(transform.position, Vector2.right, 1f, GroundMask);

        //        if (hitWall)
        //        {
        //            CancelInvoke("StopDiving");
        //            rb.AddRelativeForce(transform.right * DiveSpeed / 4);
        //            transform.eulerAngles = Vector3.forward * 90;
        //            rollTime = true;
        //            GetComponent<Animator>().SetTrigger("Bonked");
        //            Invoke("StopDiving", 5);
        //        }
        //    }
        //    else
        //    {

        //    }
      //  }
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
            //if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)))
            //{
                
            //}
            ////Move right
            //else if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && rb.velocity.x < 15)
            //{
            //    /*Vector2 newPosition = transform.position;
            //    newPosition.x += Speed * Time.deltaTime;
            //    transform.position = new Vector2(newPosition.x, newPosition.y);*/
            //    GetComponent<Animator>().SetBool("Walking", true);
            //    Left = false;
            //    rb.AddRelativeForce(transform.right * Speed);
            //    if (rb.velocity.x < 3)
            //    {
            //        rb.AddRelativeForce(transform.right * Speed);
            //    }
            //}
            ////Move left
            //else if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && rb.velocity.x > -15)
            //{
            //    /*Vector2 newPosition = transform.position;
            //    newPosition.x -= Speed * Time.deltaTime;
            //    transform.position = new Vector2(newPosition.x, newPosition.y);*/
            //    GetComponent<Animator>().SetBool("Walking", true);
            //    Left = true;
            //    rb.AddRelativeForce(transform.right * -Speed);
            //    if (rb.velocity.x > -3)
            //    {
            //        rb.AddRelativeForce(transform.right * -Speed);
            //    }
            //}
            //else
            //{
            //    Vector3 slowing = rb.velocity;
            //    slowing.x /= SlowDown;
            //    rb.velocity = slowing;
            //    Invoke("StopTalking", 0.5f);
            //}
            ////Jumping action
            //if (jumping)
            //{
            //    rb.AddForce(transform.up * Jump);

            //    if (rb.velocity.y > Jump)
            //    {
            //        rb.velocity = rb.velocity.normalized * Jump;
            //    }
            //    jumping = false;
            //    Invoke("StopJumping", 0.105f);
            //}
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
    void CoolingOff()
    {
        despairCooldown = true;
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