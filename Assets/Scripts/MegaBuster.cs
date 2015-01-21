using UnityEngine;
using System.Collections;

public class MegaBuster : MonoBehaviour {

    // <summary>
    /// Projectile prefab for shooting
    /// </summary>
    public Transform shotPrefab;

    /// <summary>
    /// Cooldown in seconds between two shots
    /// </summary>
    public float shootingRate = 0.25f;

    private float shootCooldown;
	// Use this for initialization
	void Start () {
        shootCooldown = 0f;
	}
	
	// Update is called once per frame
	void Update () {

        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
	
	}

    /// <summary>
  /// Create a new projectile if possible
  /// </summary>
  public void Attack(bool isEnemy, bool facingRight)
  {
    if (CanAttack)
    {
      shootCooldown = shootingRate;

      // Create a new shot
      var shotTransform = Instantiate(shotPrefab) as Transform;

      // Assign position
      shotTransform.position = new Vector3(transform.position.x, transform.position.y+0.2f,transform.position.z);

      // The is enemy property
      ShootScript shot = shotTransform.gameObject.GetComponent<ShootScript>();
      if (shot != null)
      {
        shot.isEnemyShot = isEnemy;
      }

      // Make the weapon shot always towards it
      MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
      if (move != null)
      {
          if (facingRight)
          {
              move.direction = this.transform.right; // towards in 2D space is the right of the sprite
              move.FacingRight = true;
          }
          else
          {
              move.direction = -this.transform.right;
              move.FacingRight = false;
          }
         
      }
    }
  }

  /// <summary>
  /// Is the weapon ready to create a new projectile?
  /// </summary>
  public bool CanAttack
  {
    get
    {
      return shootCooldown <= 0f;
    }
  }

}
