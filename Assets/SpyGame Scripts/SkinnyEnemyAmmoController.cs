using UnityEngine;
using System.Collections;

public class SkinnyEnemyAmmoController : MonoBehaviour {

    public float bulletSpeed;
    private GameObject Spy;
    public int damageToGive = 1;
    public PlayerHealthManager myManager = new PlayerHealthManager();
    public float changeInY;

    // Use this for initialization
    void Start() {
        Spy = GameObject.Find("Spy");

        if (Spy.transform.position.x < transform.position.x)
        {
            bulletSpeed = -bulletSpeed;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealthManager>().removeHealthPoint();
            Destroy(gameObject);
        }
    }

	
	// Update is called once per frame
	void Update ()
    {
        Transform bulletPosition = gameObject.transform;
        Transform targetPosition = Spy.transform;
        float changeInX = bulletSpeed * Time.deltaTime;
        //float changeInY = bulletSpeed * 0.5f * Time.deltaTime;

        Vector3 newPosition = new Vector3(gameObject.transform.position.x + changeInX, gameObject.transform.position.y+changeInY, transform.position.z);
        gameObject.transform.position = newPosition;
    }
}
