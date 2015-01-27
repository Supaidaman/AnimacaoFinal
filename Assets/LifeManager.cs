using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LifeManager : MonoBehaviour
{

    // Use this for initialization
    public Text text;
    float energia;
    private GameObject player;
    private HealthScript hs;
    void Start()
    {
        player = GameObject.Find("Player");
        text = GetComponent<Text>();
        hs = player.GetComponent<HealthScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //text.text = player.name.ToString();
        text.text = "Energia: " + hs.hp;
    }
}
