using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
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

    //score
    float startx;
    float endx;
    float score = 0;

    // Use this for initialization
    void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();

        //gameOver = Instantiate(gameOver);
        gameOver.SetActive(false);

        startx = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        GetInputButtons();
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

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
            moveSpeed = 0;
            playerDead = true;
            //do score
            endx = transform.position.x;
            score = Mathf.Floor(endx - startx);
            GameObject.Find("ScoreText").GetComponent<Text>().text = "Score " + score.ToString();
        }
    }
}
