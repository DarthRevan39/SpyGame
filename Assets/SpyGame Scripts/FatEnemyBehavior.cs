using UnityEngine;
using System.Collections;

public class FatEnemyBehavior : MonoBehaviour {

    public Vector2 position;
    public float xPos;
    [HideInInspector]
    public int countSec = 0;
    private GameObject Spy;

    public int potatoSpeed = 10;
    public GameObject Potato;
    public Transform launchPoint;

    // Use this for initialization
    void Start()
    {
        Spy = GameObject.Find("Spy");


    }

    // Update is called once per frame
    void Update() {

        position = transform.position;
        xPos = this.position.x;

        if (Spy.transform.position.x > this.position.x)
        {
            transform.localScale = new Vector3(-10, 10, 1);
        }
        else if (Spy.transform.position.x < this.position.x)
        {
            transform.localScale = new Vector3(10, 10, 1);
        }


    }

    void shootPotato()
    {

        if (countSec < 10)
        {
            countSec += 1;

        }
        else
        {
            firePotato();
            countSec = 0;
        }
    }

    void firePotato()
    {
        if (Spy.transform.position.x < transform.position.x)
        {
            potatoSpeed = -potatoSpeed;
        }
    }
}
