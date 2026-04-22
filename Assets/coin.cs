using UnityEngine;

public class coin : MonoBehaviour
{
    private float Coin = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroy(Collision.GameObject)
        collision.GetComponent<coincomponent>().AddCoin(Coin);
        Destroy(gameObject);
    }
}
