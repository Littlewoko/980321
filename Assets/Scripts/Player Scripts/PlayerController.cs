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
    [SerializeField] private float wallSlideMultiplier;
    [SerializeField] private float wallJumpDistance;
    [SerializeField] private TriggerCount groundCheck;
    [SerializeField] private int numJumps;
    [SerializeField] private TriggerCount wallCheck;

    private Rigidbody2D rb2;
    private Vector2? dirToWall;
    private Vector2 velocity;
    private float jumpVelocity;
    private float runVelocity;
    private float gravityUp;
    private float gravityDown;
    private float gravityWall;
    private float wallJumpTime;
    private int numJumpsFromGround;
    private bool onGround;
    private bool onWall;
    private bool wallJumping;
    private Transform tr;

    private void Awake()
    {
        rb2 = GetComponent<Rigidbody2D>();
        velocity = new Vector2();
        wallJumping = false;
        tr = transform;
        calculateConstants();
    }

    private void calculateConstants()
    {
        jumpVelocity = (2.0f * jumpHeight) / jumpUpTime;

        gravityUp = (jumpVelocity / jumpUpTime) / Mathf.Abs(Physics2D.gravity.y);
        gravityDown = fallGravityMultiplier * gravityUp;
        gravityWall = wallSlideMultiplier * gravityUp;

        float fallTime = Mathf.Sqrt((2.0f * jumpHeight) / Mathf.Abs(Physics2D.gravity.y * gravityDown));

        runVelocity = jumpDistance / (fallTime + jumpUpTime);

        wallJumpTime = wallJumpDistance / runVelocity;
    }

    // Start is called before the first frame update
    void Start()
    {
        onGround = (groundCheck.NumberOfObjects > 0);
        onWall = (wallCheck.NumberOfObjects > 0);
    }

    public void HitWall()
    {
        onWall = true;
        numJumpsFromGround = 0;
    }

    public void LeaveWall()
    {
        onWall = false;
        numJumpsFromGround = 1; 
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

        if (onWall)
        {
            dirToWall = wallCheck.GetDirectionToColliders(tr);
            velocity = rb2.velocity;
            velocity.y = jumpVelocity;

            if (dirToWall.HasValue)
            {
                velocity.x = -1f * Mathf.Sign(dirToWall.Value.x) * runVelocity;
                StartWallJump();
            }

            rb2.velocity = velocity;
        }
        else
        {
            velocity = rb2.velocity;
            velocity.y = jumpVelocity;
            rb2.velocity = velocity;
        }

    }

    private void Move()
    {
        if (wallJumping) return;

        velocity = rb2.velocity;
        velocity.x = Input.GetAxis("Horizontal") * runVelocity;
        rb2.velocity = velocity;
    }

    private void StartWallJump()
    {
        wallJumping = true;
        Invoke("EndWallJump", wallJumpTime);
    }

    private void EndWallJump()
    {
        wallJumping = false;
    }

    private void CheckAndSetGravity()
    {
        if (onWall)
        {
            rb2.gravityScale = gravityWall;
            return;
        }

        if (rb2.velocity.y < 0.0f)
        {
            rb2.gravityScale = gravityDown;
        } else
        {
            rb2.gravityScale = gravityUp;
        }
    }
}
