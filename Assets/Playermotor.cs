using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Playermotor : MonoBehaviour
{
    Vector2 direction;
    public float speed = -10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += new Vector3(direction.x, direction.y, 0)* Time.deltaTime * speed;
    }

    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }
}
