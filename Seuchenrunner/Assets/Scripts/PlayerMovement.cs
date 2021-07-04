using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float ClimbingSpeed;
    public PlayerController controller;             //using our CharakterScript
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;
    private Rigidbody2D rb;
    private bool Climbing;
    private float distance = 5f;
    private float inputHorizontal;
    private float inputVertical;
    private float Gravity;
    public LayerMask whatIsLadder;
    
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Gravity = rb.gravityScale;
    }

    

    // Update is called once per frame
    void Update()
    {
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("velocityX", Mathf.Abs(horizontalMove));


        // Lässt unserern Charakter springen
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("Jump", true);
        }

        // Lässt unseren Charakter sich hinknien
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    // Funktion die der Variablen "jump" ein false gibt, wenn der Charakter landet
    public void OnLanding ()
    {
        animator.SetBool("Jump", false);
        animator.SetBool("grounded", true);
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;


        /*RaycastHit2D hitInfo = Physics2D.Raycast((transform.position), Vector2.up, distance, whatIsLadder);
        if (hitInfo.collider != null)
        {
            if (Input.GetButtonDown("Vertical"))
            {
                Climbing = true;
                animator.SetBool("Climb", true);
            }

            else if (Input.GetButtonDown("Horizontal"))
            {
                Climbing = false;
                animator.SetBool("Climb", false);
            }
        }
        if (Climbing == true && hitInfo.collider != null)
        {
            inputVertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(0, inputVertical * ClimbingSpeed);
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = Gravity;
        }*/
    }

}
