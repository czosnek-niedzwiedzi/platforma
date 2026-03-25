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
    public float maxSpeed = 10;
    public float stoppingforce = 10;
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>(); 
    }


    private void FixedUpdate()
    {
        PlayerHandelingXMovement();

        MaxSpeedLimiting();

    }

    private void PlayerHandelingXMovement()
    {
        if (direction.x != 0)
        {
            rigidbody2D.AddForce(new Vector2(direction.x * speed, 0));
        }
        else if (rigidbody2D.linearVelocityX != 0)
        {
            rigidbody2D.AddForce(new Vector2(-rigidbody2D.linearVelocityX * stoppingforce, 0));
        }
    }

    private void MaxSpeedLimiting()
    {
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
            canJump = false;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }

   
       
}
