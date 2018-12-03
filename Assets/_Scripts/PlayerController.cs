using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    float current_speed = 0;
    public float jumpForce;

    private Rigidbody2D myRigidbody;
    private Collider2D myCollider;
    private Animator myAnimator;

    public bool grounded;
    bool sliding;
    public LayerMask whatIsGround;

    bool JumpButton;
    bool SlideButton;

    public float slideTime;
    float currentSlideTime;
    bool canSlide;
    public float slidingReload;
    float currentSlidingReload;

    bool playerDead;
    public GameObject gameOver;

    public GameObject startUI;
    float start_timer;

    //score
    float startx;
    float endx;
    float score = 0;

    //sunrise
    public GameObject Sunrise;
    public float initial_sunrise_distance;
    float current_sunrise_distance = -10;
    float sunrise_distance;
    public GameObject dustParticle;
    bool playerDusted = false;

    // Use this for initialization
    void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();

        //gameOver = Instantiate(gameOver);
        gameOver.SetActive(false);

        startx = transform.position.x;

        sunrise_distance = initial_sunrise_distance;
    }
	
	// Update is called once per frame
	void Update () {
        GetInputButtons();
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        myRigidbody.velocity = new Vector2(current_speed, myRigidbody.velocity.y);

        StartRunning();

        if (JumpButton && grounded && !sliding) { 
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
        }

        if (SlideButton && grounded && !sliding && canSlide)
        {
            sliding = true;
            currentSlideTime = 0;
        }

        if (sliding)
        {
            currentSlideTime += Time.deltaTime;
            if (currentSlideTime >= slideTime)
            {
                sliding = false;
                canSlide = false;
                currentSlidingReload = slidingReload;
            }
        }

        if (!canSlide)
        {
            currentSlidingReload -= Time.deltaTime;
            if (currentSlidingReload <= 0)
            {
                canSlide = true;
            }
        }

        //set animation
        myAnimator.SetBool("isGrounded", grounded);
        myAnimator.SetBool("isSliding", sliding);
        myAnimator.SetBool("isDead", playerDead);

        //check death from falling (y position being too low)
        if (transform.position.y < -5)
        {
            PlayerDie();
        }

        //sunrise stuff
        MoveSunrise();
    }

    void MoveSunrise()
    {
        Vector2 pos = Sunrise.transform.position;
        pos.x = transform.position.x + current_sunrise_distance;
        Sunrise.transform.position = pos;

        current_sunrise_distance = Mathf.Lerp(current_sunrise_distance, sunrise_distance, 0.5f * Time.deltaTime);
    }

    void StartRunning()
    {
        //lerp to the running speed
        if (!playerDead) current_speed = Mathf.Lerp(current_speed, moveSpeed, 0.4f * Time.deltaTime);
        //flash the message on the screen while speeding up running
        if (current_speed < 5 && !playerDead)
        {
            if (start_timer > 0.2f)
            {
                start_timer = 0;
                startUI.SetActive(!startUI.activeSelf);
            }

            start_timer += Time.deltaTime;
        }
        else
        {
            startUI.SetActive(false);
        }

    }

    void GetInputButtons()
    {
        JumpButton = false;
        SlideButton = false;

        //Jump down
        if (Input.GetKeyDown(KeyCode.Z)){ //add mobile input here for mobile testing later. (||) use those to define OR later, your stupid keyboard doesnt have them. 
            JumpButton = true;
        }

        //Sliding button down
        if (Input.GetKey(KeyCode.X))
        { //add mobile input here for mobile testing later. (||) use those to define OR later, your stupid keyboard doesnt have them. 
            SlideButton = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "hazard")
        {
            PlayerDie();
        }

        if (collision.tag == "sunrise_tag" && !playerDusted)
        {
            playerDusted = true;
            GetComponent<Renderer>().enabled = false;
            Instantiate(dustParticle, transform.position, Quaternion.identity);
        }
    }


    public void GetPowerup()
    {
        Debug.Log("Powerup Collected!!!");
    }

    public void PlayerDie()
    {
        if (!playerDead)
        {
            //set variables
            gameOver.SetActive(true);
            current_speed = 0;
            playerDead = true;
            sunrise_distance = -0.1f;
            //do score
            endx = transform.position.x;
            score = Mathf.Floor(endx - startx);
            GameObject.Find("ScoreText").GetComponent<Text>().text = "Score " + score.ToString();
        }
    }
}
