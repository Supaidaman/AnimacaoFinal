using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour
{
    /// <summary>
    /// Total hitpoints
    /// </summary>
    public int hp = 1;
    //Animation deathAnim;
    /// <summary>
    /// Enemy or player?
    /// </summary>
    public bool isEnemy = true;
    private Animator anim;
    /// <summary>
    /// Inflicts damage and check if the object should be destroyed
    /// </summary>
    /// <param name="damageCount"></param>
    /// 
    public void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Damage(int damageCount)
    {
        hp -= damageCount;

        if (hp <= 0)
        {
            if (!isEnemy) 
            {
                MMController controlador = GetComponent<MMController>();
                controlador.transform.position = controlador.StartPosition;
                return;
            }

            anim.SetBool("dead", true);
            
            Destroy(gameObject,0.50f);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Is this a shot?
        ShootScript shot = otherCollider.gameObject.GetComponent<ShootScript>();
        if (shot != null)
        {
            // Avoid friendly fire
            if (shot.isEnemyShot != isEnemy)
            {
                Damage(shot.damage);

                // Destroy the shot
                Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
            }
        }

        if(otherCollider.tag=="Enemy")
        {
            Damage(1);
        }
    }
}