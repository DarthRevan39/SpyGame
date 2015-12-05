using UnityEngine;
using System.Collections;

public class PlayerAmmoController : MonoBehaviour {

    public int pointsForKill;
    public int bulletSpeed;
    public int damageToGive = 1;
    private GameObject Spy;
    public PlayerHealthManager myManager = new PlayerHealthManager();

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
        if (collision.tag == "FatEnemy")
        {
            int pointIncrease = collision.GetComponent<EnemyHealthManager>().pointsOnDeath;
            Spy.GetComponent<ScoreManager>().addPointAmount(pointIncrease);
            collision.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
            Destroy(gameObject);
        }

        if (collision.tag == "SkinnyEnemy")
        {
            collision.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
            int pointIncrease = collision.GetComponent<EnemyHealthManager>().pointsOnDeath;
            Spy.GetComponent<ScoreManager>().addPointAmount(pointIncrease);
            Destroy(gameObject);
        }

    }

	
	// Update is called once per frame
	void Update ()
    {
    }
}
