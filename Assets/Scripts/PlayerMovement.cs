using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    public CharacterController controller;
    public Animator animator;
    public float horizontal;
    public float speed = 10f;
    public bool isAttacking;
    public bool isJumping;
    public GameObject fireballPrefab;
    public Transform FireballShootPosition;
   //public float nextFireballTime=0f;
    //public float fireballTimeGap;
    public float jumpForce=7f;
    public float gravity = -10f;
    public Vector3 jumpVelocity;
    public LayerMask groundLayer;
    public Transform groundCheckPosition;
    public bool isGrounded;


    private void Start()
    {
        
   
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
       // nextFireballTime = Time.time;
        //nextJumpTime = Time.time;
       
    }


    private void Update()
    {
        if (transform.position.x < 0 || transform.position.x > 0)
        {
            this.gameObject.transform.position = new Vector3(0f, transform.position.y, transform.position.z);
        }

        if(horizontal < 0 || horizontal > 0)
        {
            isAttacking = false;
        animator.SetBool("IsAttacking", isAttacking);
        }
        isGrounded = Physics.CheckSphere(groundCheckPosition.position, 0.3f, groundLayer);

        horizontal = Input.GetAxisRaw("Horizontal");

        if(isGrounded && jumpVelocity.y <0f)
        {
            isJumping = false;
            jumpVelocity.y = 0f;
        }

        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                isJumping = true;
                Jump();
            }
        }
        else
        {
            jumpVelocity.y += gravity * Time.deltaTime;
        }


        if (Input.GetKeyDown(KeyCode.Z))
        {
            isAttacking = true;
            animator.SetBool("IsAttacking", isAttacking);
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            isAttacking = false;
            animator.SetBool("IsAttacking", isAttacking);
        }



        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("IsAttackingFireball", true);
            FireAttack();
        }
  
        //Debug.Log(isGrounded);

        animator.SetBool("IsJumping", isJumping);
        animator.SetBool("IsAttackingFireball", false);
    }


    private void FixedUpdate()
    {
        

        animator.SetFloat("Horizontal", horizontal);

        controller.Move(transform.forward * horizontal*speed*Time.deltaTime);
        controller.Move(jumpVelocity * Time.deltaTime);
 
        
    }




    public void Jump()
    {
        isAttacking = false;
        animator.SetBool("IsAttacking", isAttacking);
        jumpVelocity.y = jumpForce;
        animator.SetBool("IsJumping", isJumping);
        //nextJumpTime = jumpTime;
    }


    public void FireAttack()
    {
        isAttacking = false;
        animator.SetBool("IsAttacking", isAttacking);
        GameObject fireball = Instantiate(fireballPrefab);
        fireball.transform.position = FireballShootPosition.position;

        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 500f);
       
    }


    
}
