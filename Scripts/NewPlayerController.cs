using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : MonoBehaviour {

    public float maxSpeed = 10f;
    bool facingRight = true;
    Rigidbody2D rb;
    public bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.5f;
    public LayerMask ground;
    public float jumpForce = 7000f;
    Animator anim;
    float move;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
	void FixedUpdate () {
        if (!grounded) return;
        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);    

        if(move>0 && !facingRight)
        {
            Flip();
        }
        if (move < 0 && facingRight)
        {
            Flip();
        }
    }
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        if (move != 0)
        {
            anim.SetBool("isWalking", true);
        }
        if (move == 0)
        {
            anim.SetBool("isWalking", false);
        }
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, ground);
        anim.SetBool("isGrounded", grounded);
        if (grounded && Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
