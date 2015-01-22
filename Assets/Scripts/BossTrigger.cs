using UnityEngine;
using System.Collections;

public class BossTrigger : MonoBehaviour {

	// Use this for initialization
    public GameObject boss;
    private EnemyScript enemy;
	void Awake () {
      //  enemy =
	
	}
	
	// Update is called once per frame
   

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            Debug.Log(":(");
            return;
        }
        


        Debug.Log("uhul");
        boss.GetComponent<EnemyScript>().enabled = true;

   
  
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            Debug.Log(":(");
            return;
        }



        Debug.Log("uhul");
        boss.GetComponent<EnemyScript>().enabled = false;
    }
}
