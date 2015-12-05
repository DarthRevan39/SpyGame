using UnityEngine;
using System.Collections;

public class PlayerHealthManager : MonoBehaviour {

    
    
    [HideInInspector]
    public bool isDead = false;
    public int lives = 5;


    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (lives > 0)
            return;
        else
        {
            isDead = true;
            DestroyObject(GameObject.Find("Spy"));
        }
	}

    public void removeHealthPoint()
    {
        lives--;
    }

    public void powerUpFullHealth()
    {
        lives = 5;
    }
}
