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

	void Start () {
		rb = GetComponent<Rigidbody2D>();
    }
	
	void FixedUpdate () {

        if (!grounded) return;
        float move = Input.GetAxis("Horizontal");

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
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, ground);
        if (grounded && Input.GetKeyDown(KeyCode.Space))
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
