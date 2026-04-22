using System;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public float MaxHP = 10;
    private float HP;
    private bool Godmode;

    public delegate void OnHealthChangeHandler(float newHealth, float amountChange);
    public event OnHealthChangeHandler OnHealthChange;

    public delegate void OnHealthInitializedHandler(float HP);
    public event OnHealthInitializedHandler OnHealthInitialized;

    public coincomponent coincomponent;
    public TextMeshProUGUI textComponent;
    void Start()
    {
        HP = MaxHP;
        OnHealthInitialized?.Invoke(HP);
        coincomponent.OnCoinInitialized += OnCoinInitialized;
   
    }

    private void OnCoinInitialized(float Bank)
    {
        if (Bank == 3) 
        {
            HP += 5;
            Debug.Log(HP);
            if (HP > MaxHP)
            {
                HP = MaxHP;
                Debug.Log(HP);
            }
          
        }

    }

    void Update()
    {  

        
    }
    public void AddDamage(float damage)
    {
        if (!Godmode)
        {
            HP -= damage;
            Debug.Log(HP);
            if (HP <= 0)
            {
                Destroy(this.gameObject);
            }
            OnHealthChange?.Invoke(HP, damage);
            Godmode = true;
            StartCoroutine(ResetGodMode(3));
        }
       
    }
 IEnumerator ResetGodMode(float resetTime)
    {
        yield return new WaitForSeconds(resetTime);
        Godmode = false;
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
        OnHealthChange?.Invoke(HP, Heal);      
    }

    

}
