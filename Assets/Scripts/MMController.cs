using UnityEngine;
using System.Collections;

public class MMController : MonoBehaviour {
	public bool grounded = false;
	public float maxSpeed = 10;
	bool facingRight = true;
	Animator anim;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;
    Vector3 startPosition;

    public Vector3 StartPosition
    {
        get { return startPosition; }
        set { startPosition = value; }
    }
    public bool FacingRight
    {
        get { return facingRight; }

    }
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
        startPosition = transform.position;
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
      //  if(Input.GetKeyUp(KeyCode.Space)==false)
		    anim.SetBool("ground",grounded);
      //  Debug.Log(Input.GetKeyDown(KeyCode.Space).ToString());
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
        if (rigidbody2D.position.y < -10)
        {
            transform.position = startPosition;
            HealthScript hp = GetComponent<HealthScript>();
            hp.hp = hp.StartHP;

        }

		if(grounded && Input.GetKeyDown(KeyCode.Space))
		{
			anim.SetBool("ground",false);
			rigidbody2D.AddForce(new Vector2(0,jumpForce));
            return;

		}

        // 5 - Shooting
        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");
        // Careful: For Mac users, ctrl + arrow is a bad idea
        anim.SetBool("shoot", shoot);
        if (shoot)
        {
            MegaBuster weapon = GetComponent<MegaBuster>();
            if (weapon != null)
            {
              // anim.SetBool("shoot", shoot);
                // false because the player is not an enemy
                weapon.Attack(false,facingRight);
            }
          
           // anim.SetBool("shoot", false);
          
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
