using UnityEngine;
using System.Collections;

public class SkinnyEnemyBehavior : MonoBehaviour
{
    public Vector2 position;
    public float xPos;
    private GameObject Spy;
    private float startTime;
    public GameObject bullet;
    private int updateCount = 0;
    public int updateTime= 4;

    // Use this for initialization
    void Start()
    {
        Spy = GameObject.Find("Spy");
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        position = transform.position;
        xPos = this.position.x;

        if (Spy.transform.position.x > this.position.x)
        {
            transform.localScale = new Vector3(-6, 6, 1);
        }
        else if (Spy.transform.position.x < this.position.x)
        {
            transform.localScale = new Vector3(6, 6, 1);
        }
        updateCount++;


        if (Mathf.Abs(this.position.x - Spy.transform.position.x) < 10)
        {

            Vector3 bulletSpawn = transform.position;
            if (Spy.transform.position.x > this.position.x)
                bulletSpawn.x = bulletSpawn.x + 2;
            else
                bulletSpawn.x = bulletSpawn.x - 2;

            if (updateCount % updateTime == 0)
            {
                Instantiate(bullet, bulletSpawn, transform.rotation);
               /* if (Random.value > .5)
                    changeInY = Random.value / 2;
                else
                    changeInY = Random.value / -2;*/
            }
        } 



    }
}
