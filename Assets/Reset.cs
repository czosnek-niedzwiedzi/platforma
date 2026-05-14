using UnityEngine;

public class Reset : MonoBehaviour
{
    public Transform position;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        collision.transform.position = position.position;
       
    }

    
    }
