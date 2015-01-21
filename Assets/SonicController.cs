using UnityEngine;
using System.Collections;

public class SonicController : MonoBehaviour {
	public bool grounded = false;
	public float maxSpeed = 10;
	bool facingRight = true;
	Animator anim;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
        if(Input.GetKeyUp(KeyCode.Space)==false)
		    anim.SetBool("ground",grounded);
        Debug.Log(Input.GetKeyDown(KeyCode.Space).ToString());
		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat("speed", Mathf.Abs(move));
		anim.SetFloat ("vSpeed",rigidbody2D.velocity.y);
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		if (move > 0 && !facingRight)
						Flip ();
				else if (move < 0 && facingRight)
						Flip ();

	}
	void Update()
	{
		if(grounded && Input.GetKeyDown(KeyCode.Space))
		{
			anim.SetBool("ground",false);
			rigidbody2D.AddForce(new Vector2(0,jumpForce));
            return;

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
