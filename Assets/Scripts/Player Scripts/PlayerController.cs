using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpHeight;
    [SerializeField] private float jumpUpTime;
    [SerializeField] private float jumpDistance;
    [SerializeField] private float fallGravityMultiplier;
    [SerializeField] private TriggerCount groundCheck;
    [SerializeField] private int numJumps;

    private Rigidbody2D rb2;
    private Vector2 velocity;
    private float jumpVelocity;
    private float runVelocity;
    private float gravityUp;
    private float gravityDown;
    private int numJumpsFromGround;
    private bool onGround;

    private void Awake()
    {
        rb2 = GetComponent<Rigidbody2D>();
        velocity = new Vector2();
        calculateConstants();
    }

    private void calculateConstants()
    {
        jumpVelocity = (2.0f * jumpHeight) / jumpUpTime;

        gravityUp = (jumpVelocity / jumpUpTime) / Mathf.Abs(Physics2D.gravity.y);
        gravityDown = fallGravityMultiplier * gravityUp;

        float fallTime = Mathf.Sqrt((2.0f * jumpHeight) / Mathf.Abs(Physics2D.gravity.y * gravityDown));

        runVelocity = jumpDistance / (fallTime + jumpUpTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        onGround = (groundCheck.NumberOfObjects > 0);
    }

    public void HitGround()
    {
        onGround = true;
        numJumpsFromGround = 0;
    }

    public void LeftGround()
    {
        onGround = false;
        numJumpsFromGround = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            jump();
        }

        Move();
    }

    private void FixedUpdate()
    {
        CheckAndSetGravity();
    }

    private void jump() 
    {
        if ((!onGround) && (numJumpsFromGround >= numJumps)) return;

        numJumpsFromGround++;

        velocity = rb2.velocity;
        velocity.y = jumpVelocity;
        rb2.velocity = velocity;


        
    }

    private void Move()
    {
        velocity = rb2.velocity;
        velocity.x = Input.GetAxis("Horizontal") * runVelocity;
        rb2.velocity = velocity;
    }

    private void CheckAndSetGravity()
    {
        if (rb2.velocity.y < 0.0f)
        {
            rb2.gravityScale = gravityDown;
        } else
        {
            rb2.gravityScale = gravityUp;
        }
    }
}
