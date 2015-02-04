using UnityEngine;
using System.Collections;
using System;
public class HealthScript : MonoBehaviour
{
    /// <summary>
    /// Total hitpoints
    /// </summary>
    ///
    private int startHp;
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
    public int StartHP
    {
        get { return startHp; }
    }
    public void Start()
    {
        startHp = hp;
        anim = GetComponent<Animator>();
    }
    public void Damage(int damageCount)
    {
        hp -= damageCount;

        if (hp <= 0)
        {
            anim.SetBool("dead", true);
            if (!isEnemy)
            {
                StartCoroutine("Death");

                Application.LoadLevel(0);
                return;
            }



            Destroy(gameObject, 0.50f);
        }
        //else 
        //{
        //    if (!isEnemy)
        //    {
        //        StartCoroutine("Knockback");


        //        return;
        //    }

        //}
    }
    IEnumerator Knockback()
    {
        yield return new WaitForSeconds(0.03f);
        //anim.SetBool("dead", false);
        MMController controlador = GetComponent<MMController>();
        Vector3 newPos = new Vector3 (controlador.transform.position.x - (1.5f * Convert.ToInt32(controlador.FacingRight)), 
            controlador.transform.position.y,controlador.transform.position.z);
        controlador.transform.position = newPos;
        //hp = startHp;
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(0.50f);
        anim.SetBool("dead", false);
        MMController controlador = GetComponent<MMController>();
        controlador.transform.position = controlador.StartPosition;
        hp = startHp;
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