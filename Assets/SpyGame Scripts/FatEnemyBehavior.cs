using UnityEngine;
using System.Collections;

public class FatEnemyBehavior : MonoBehaviour {

    private PlayerController playerController;
    public Vector2 position;
    public float xPos;

	// Use this for initialization
	void Start ()
    {
        playerController = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {

        position = transform.position;
        xPos = position.x;

        if ( playerController.position.x > xPos)
        {
            transform.localScale = new Vector3(10, 10, 1);
        }
        else if (playerController.position.x < xPos)
        {
            transform.localScale = new Vector3(-10, 10, 1);
        }
    }
}
