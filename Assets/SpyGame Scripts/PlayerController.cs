using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using WReader;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour
{ 
    //Player handling
    public float speed = 10;
    public float acceleration = 100;
    public Vector2 position;
    public LayerMask GroundLayers;
    public float JumpSpeed = 100f;
    public Text scoreText;
    public Text healthText;

    private Transform m_GroundCheck;

    private float currentSpeed;
    private float targetSpeed;
    private Vector2 amountToMove;
    [HideInInspector]
    public PlayerHealthManager myHealthManager;
    private PlayerPhysics playerPhysics;

    // Use this for initialization
    void Start()
    {
        setHealthText();
        playerPhysics = GetComponent<PlayerPhysics>();
        m_GroundCheck = transform.FindChild("GroundCheck");
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

        if(Input.GetButtonDown("Jump"))
        {
            bool isGrounded = Physics2D.OverlapPoint(m_GroundCheck.position, GroundLayers);         
            if (isGrounded)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * JumpSpeed, ForceMode2D.Impulse);

            }
            /*
            if (WeatherGrab.GetConditions("31204").Contains("Cloudyz"))
            {

                GetComponent<Rigidbody2D>().AddForce(Vector2.up * JumpSpeed*4, ForceMode2D.Impulse);
            }
            */
        }
        setHealthText();
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

    public void setScoreText()
    {
        
    }

    public void setHealthText()
    {
        GameObject Spy = GameObject.Find("Spy");
        healthText.text = "Lives: " + Spy.GetComponent<PlayerHealthManager>().lives.ToString();
        switch(Spy.GetComponent<PlayerHealthManager>().lives)
        {
            case 1:
                healthText.color = Color.red;
                break;
            case 2:
                healthText.color = Color.yellow;
                break;
            case 3:
                healthText.color = Color.yellow;
                break;
            case 4:
                healthText.color = Color.green;
                break;
            case 5:
                healthText.color = Color.green;
                break;
            default:
                healthText.color = Color.red;
                Spy.GetComponent<PlayerHealthManager>().lives = 0;
                break;
        }
    }

}
