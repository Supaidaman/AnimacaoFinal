using UnityEngine;
using System.Collections;

public class BassAnimation : MonoBehaviour {
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    anim.SetBool("bossActive", GetComponent<EnemyScript>().enabled);
	}
}
