using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public float MaxHP = 10;

    private float HP;


    void Start()
    {
        HP = MaxHP;

    } 
  
    void Update()
    {  

        
    }
    public void AddDamage(float damage)
    {
        HP -= damage;
        Debug.Log(HP);
        if (HP <= 0)
        { 
        Destroy(this.gameObject);
        }
        
    }

    public void AddHealth(float Heal)
    {
        HP += Heal;
        Debug.Log(HP);
        if (HP > MaxHP) 
        {
            HP = MaxHP;
            Debug.Log(HP);
        }
    }
}
