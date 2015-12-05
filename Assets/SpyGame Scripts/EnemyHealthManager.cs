using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

    public int enemyHealth;
    public int pointsOnDeath;

	// Use this for initialization
	void Start () {

        float value = Random.value;

        if (value < 0.2)
            enemyHealth = 1;
        else if (value < 0.4)
            enemyHealth = 2;
        else if (value < 0.6)
            enemyHealth = 3;
        else if (value < 0.8)
            enemyHealth = 4;
        else if (value < 0.99)
            enemyHealth = 10;
        else
            enemyHealth = 5;
   }

    // Update is called once per frame
    void Update() {
        if (enemyHealth <= 0)
        {
            //  ScoreManager.AddPoints(pointsOnDeath);
            Destroy(gameObject);
        }
	}

    public void giveDamage(int damageToGive)
    {
        enemyHealth -= damageToGive;
    }
}
