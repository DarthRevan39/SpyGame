using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour
{


    //Player handling
    public float speed = 8;
    public float acceleration = 100;
    public Vector2 position;

    private float currentSpeed;
    private float targetSpeed;
    private Vector2 amountToMove;

    private PlayerPhysics playerPhysics;

    // Use this for initialization
    void Start()
    {
        playerPhysics = GetComponent<PlayerPhysics>();
    }

    // Update is called once per frame
    void Update()
    {
        targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
        currentSpeed = incrementTowards(currentSpeed, targetSpeed, acceleration);

        amountToMove = new Vector2(currentSpeed, 0);
        playerPhysics.Move(amountToMove * Time.deltaTime);

        if (currentSpeed > 0)
        {
            transform.localScale = new Vector3(10, 10, 1);
        }
        else if (currentSpeed < 0)
        {
            transform.localScale = new Vector3(-10, 10, 1);
        }
        position = transform.position;
    }

    private float incrementTowards(float n, float target, float a)
    {
        if (n == target)
            return n;
        else
        {
            float dir = Mathf.Sign(target - n);
            n += a * Time.deltaTime * dir;
            return (dir == Mathf.Sign(target - n)) ? n : target;
        }
    }
}
