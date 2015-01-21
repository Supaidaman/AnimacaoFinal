using UnityEngine;

/// <summary>
/// Simply moves the current game object
/// </summary>
public class MoveScript : MonoBehaviour
{
    // 1 - Designer variables

    /// <summary>
    /// Object speed
    /// </summary>
    public Vector2 speed = new Vector2(10, 10);

    /// <summary>
    /// Moving direction
    /// </summary>
    public Vector2 direction = new Vector2(-1, 0);
    Animator anim;
    private Vector2 movement;
    bool facingRight = true;

    public bool FacingRight
    {
        get { return facingRight; }
        set { facingRight = value; }
    }
    void Update()
    {
        // 2 - Movement
        movement = new Vector2(
          speed.x * direction.x,
          speed.y * direction.y);
    }

    void FixedUpdate()
    {
        // Apply movement to the rigidbody
        rigidbody2D.velocity = movement;
        if (!facingRight)
            Flip();
       
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}