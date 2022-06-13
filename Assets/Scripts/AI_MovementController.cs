using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AI_MovementController : MonoBehaviour
{

    public CharacterController controller;
    public Animator animator;
    public float horizontal;
    public float speed = 4f;
    public bool isAttacking;
    public bool isJumping;
    public Transform playerPosition;
    public GameObject fireballPrefab;
    public Transform FireballShootPosition;
    public float nextFireballTime;
    public float fireballTimeGap = 0.5f;
    public float jumpForce = 7f;
    public float gravity = -10f;
    public Vector3 jumpVelocity;
    public LayerMask groundLayer;
    public Transform groundCheckPosition;
    public bool isGrounded;
    public Transform rayPoint;
    


    private void Start()
    {
        nextFireballTime = Time.time;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    
    }
    private void Update()
    {
        if (transform.position.x < 0 || transform.position.x > 0)
        {
            this.gameObject.transform.position = new Vector3(0f, transform.position.y, transform.position.z);
        }


        isGrounded = Physics.CheckSphere(groundCheckPosition.position, 0.3f, groundLayer);

        Ray ray = new Ray(rayPoint.position,transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1f))
        {
            //Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.CompareTag("MyFireball"))
            {
                //Debug.Log("IsAvoiding");
                if (isGrounded)
                {
                    //Debug.Log(isGrounded);
                    animator.SetBool("IsJumping", isJumping);
                    isJumping = true;
                    Jump();
                }
                
            }
        }
        else
        {
            if (Physics.Raycast(ray, out hit, 0.1f))
            {
                // Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    
                    
                    StartAttacking();
                }

            }
            else if (Physics.Raycast(ray, out hit, 100f))
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    isAttacking = false;
                   
                    animator.SetBool("IsAttackingFireball", true);
                    FireAttack();
                }
            }
        }
        
        //else
        //{
        //    StartMoving -= MoveStop;
        //    StartMoving = MoveForward;
        //}


        //StartMoving();
        

        Ray ray2 = new Ray(FireballShootPosition.position, transform.up);
        if (Physics.Raycast(ray, out hit, 1f))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                StartAttacking();
            }
        }

        
        
        animator.SetBool("IsAttacking", isAttacking);
        animator.SetBool("IsAttackingFireball", false);
    }





   
    private void FixedUpdate()
    {
        
        if (Mathf.Abs(playerPosition.position.z - transform.position.z) > 4)
        {
            isAttacking = false;
            animator.SetBool("IsAttackingFireball", true);
            FireAttack();
        }
        else
        {
            isAttacking = true;
        }

        if (isGrounded && jumpVelocity.y < 0f)
        {
            isJumping = false;
            animator.SetBool("IsJumping", isJumping);
            jumpVelocity.y = 0f;
        }
        else if(!isGrounded)
        {

            jumpVelocity.y += gravity * Time.deltaTime;
        }

        animator.SetFloat("Horizontal", horizontal);

        controller.Move(transform.forward * horizontal * speed * Time.deltaTime);
        controller.Move(jumpVelocity * Time.deltaTime);

        
    }


    public void MoveForward()
    {
        horizontal = 1f;
    }

    public void MoveStop()
    {
        horizontal = 0f;
    }
    private void StartAttacking()
    {

        isAttacking = true;
        animator.SetBool("IsAttacking", isAttacking);
    }



    public void Jump()
    {
        Debug.Log("Jumping");
        jumpVelocity.y = jumpForce;
        animator.SetBool("IsJumping", isJumping);
    }


    public void FireAttack()
    {
        if (Time.time > nextFireballTime)
        {
            //Debug.Log("Attacking fire");
            GameObject fireball = Instantiate(fireballPrefab);
            fireball.transform.position = FireballShootPosition.position;

            Rigidbody rb = fireball.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 500f);
            nextFireballTime = Time.time + fireballTimeGap;
        }
    }



    
}
