using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
    private MegaBuster weapon;

    void Awake()
    {
        // Retrieve the weapon only once
        weapon = GetComponent<MegaBuster>();
    }

    void Update()
    {

        // Auto-fire
        if (weapon != null && weapon.CanAttack)
        {
            weapon.Attack(true,false);
        }
    }
}
