using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float Speed = 10.0f;
    public float JumpSpeed = 0.2f;
    public LayerMask GroundLayers;


    private Animator m_Animator;
    private Transform m_GroundCheck;
    

	// Use this for initialization
	void Start ()
    {
        m_Animator = GetComponent<Animator>();
        m_GroundCheck = transform.FindChild("GroundCheck");
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (Input.GetButton("Jump"))
        {
            bool isGrounded = Physics2D.OverlapPoint(m_GroundCheck.position, GroundLayers);

            if (isGrounded)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * JumpSpeed, ForceMode2D.Impulse);

            }
        }
        float hSpeed = Input.GetAxis("Horizontal");
        
        m_Animator.SetFloat("Speed", Mathf.Abs(hSpeed));

        if(hSpeed > 0)
        {
            transform.localScale = new Vector3(80, 80, 1);
        }
        else if(hSpeed < 0)
        {
            transform.localScale = new Vector3(-80, 80, 1);
        }

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(hSpeed * Speed, this.GetComponent<Rigidbody2D>().velocity.y);
	}
}
