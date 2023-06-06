using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [Header("Movement")] 
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float acceleration = 10;
    [SerializeField] private float decceleration = 10;
    [SerializeField] private float velPower = 1f;
    [SerializeField] private float frictionAmount = 0.2f;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 400f;
    [SerializeField] private float groundTime = 0.2f;
    [SerializeField] private float jumpBufferTime = 0.2f;
    [SerializeField] private float fallGravityScale = 1.9f;
    [SerializeField] private float gravityScale = 4f;
    
    [Header("Additional")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private LayerMask groundLayer;  




    private Vector3 groundCheckSize = new Vector3(.2f, .2f, 0);
    private float lastGroundTime;
    private float lastJumpBufferTime;
    private float horizontal;

    private bool IsJumping = false;
    private bool jumpInputPressed = false;
    private bool m_FacingRight = true;
    public bool disabled = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        lastGroundTime = 0;
        lastJumpBufferTime = 0;

       
    }

    private void Update() 
    {
        bool isGrounded = IsOnGround();
        
        if(!disabled)
        {
                #region Jump
            jumpInputPressed = Input.GetButtonDown("Jump");
            if(jumpInputPressed)
                lastJumpBufferTime = jumpBufferTime;
            if(isGrounded)
                lastGroundTime = groundTime;

            #region Timer
                lastGroundTime -= Time.deltaTime;
                lastJumpBufferTime -= Time.deltaTime;
            #endregion    
            
            //Debug.Log("lastGroundTime: " + lastGroundTime + "  lastJumpBufferTime: " + lastJumpBufferTime);

            if(lastGroundTime > 0 && lastJumpBufferTime > 0 && !IsJumping)
                Jump();
            
            #endregion

            horizontal = Input.GetAxisRaw("Horizontal");
        }


        
       

    }

    private void FixedUpdate() 
    {

        #region Jump gravity
        if(rb.velocity.y < 0)
            rb.gravityScale = gravityScale * fallGravityScale;
        else
            rb.gravityScale = gravityScale;
        #endregion

        Move();

        if (horizontal > 0 && !m_FacingRight)
		{
				// ... flip the player.
			Flip();
		}
		// Otherwise if the input is moving the player left and the player is facing right...
		else if (horizontal < 0 && m_FacingRight)
		{
			// ... flip the player.
			Flip();
		}



    }

    private void Move()
    {

        #region Run

        float targetSpeed = horizontal * moveSpeed;

        float speedDif = targetSpeed - rb.velocity.x;

        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;

        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);

        rb.AddForce(movement * Vector2.right);

        #endregion

        #region friction


        if(lastGroundTime > 0 && Mathf.Abs(horizontal) < 0.01f)
        {

             float amount = Mathf.Min(Mathf.Abs(rb.velocity.x), Mathf.Abs(frictionAmount));

             amount *= Mathf.Sign(rb.velocity.x) * -1;
             rb.AddForce(Vector2.right * amount, ForceMode2D.Impulse);
        }

        #endregion



    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);

        IsJumping = true;
        jumpInputPressed = false;

    }

    private bool IsOnGround()
    {
        if(Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0, groundLayer))
        {
            IsJumping = false;
            return true;
        }
        else
            return false;
        /*Collider[] hitColliders = Physics.OverlapSphere(groundCheckPoint.position, 0.1f);
        foreach (var hitCollider in hitColliders)
        {
            if(hitCollider.gameObject.tag == "Ground")
            {
                IsJumping = false;
                return true;
            }
        }
        
        return false;*/
    }
    
    	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
