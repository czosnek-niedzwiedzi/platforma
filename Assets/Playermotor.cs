using System.Collections;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Playermotor : MonoBehaviour
{
    Vector2 direction;
    Rigidbody2D rigidbody2D;
    public float speed = 10;
    public float jump = 10;
    private bool canJump = true;
    private bool canDash = true;
    public float maxSpeed = 10;
    public float stoppingforce = 10;
    public float dashPower = 10;
    public float skoki = 2;
    private Animator animator;
    private float initScale;
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>();
        initScale = transform.localScale.x;
    }


    private void FixedUpdate()
    {
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(initScale, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(-initScale, transform.localScale.y, transform.localScale.z);
        }
            PlayerHandelingXMovement();

        MaxSpeedLimiting();

    }

    private void PlayerHandelingXMovement()
    {
        if (direction.x != 0)
        {
            rigidbody2D.AddForce(new Vector2(direction.x * speed, 0));
            animator.SetBool("IsMoving", true);
        }
        else if (rigidbody2D.linearVelocityX != 0)
        {
            rigidbody2D.AddForce(new Vector2(-rigidbody2D.linearVelocityX * stoppingforce, 0));
        }

        if (direction.x == 0)
        {
            animator.SetBool("IsMoving", false);
        }
    }

    private void MaxSpeedLimiting()
    {
        if (!canDash)
        {
            return;
        }

            if (rigidbody2D.linearVelocityX >= maxSpeed)
            {
                rigidbody2D.linearVelocityX = maxSpeed;
            }
            else if (rigidbody2D.linearVelocityX <= -maxSpeed)
            {
                rigidbody2D.linearVelocityX = -maxSpeed;
            }
        
    }

    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }

    private void OnJump()
    {
        if(canJump)
        {
            //Debug.Log("Jump");
            rigidbody2D.AddForce(Vector2.up * 10 * jump, ForceMode2D.Impulse);

            skoki--;

        }

        if(skoki < 1)
        {
            canJump = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        skoki = 2;

        if (skoki > 1)
        {
            canJump = true;
        }
    }

    private void OnDash()
    { 
        // Debug.Log("Dashing");
        if (canDash)
        {
            if (direction.x != 0)
            {
                rigidbody2D.AddForce(new Vector2(direction.x * dashPower, 0), ForceMode2D.Impulse);
            }
            else
            {
              rigidbody2D.AddForce(new Vector2(direction.x * dashPower, 0), ForceMode2D.Impulse);
            }
            canDash = false;
            StartCoroutine(ResetDash(1));
            
        }

        IEnumerator ResetDash(float cooldown) 
        {
        yield return new WaitForSeconds(cooldown);
            canDash = true;
        }
    }  
}
