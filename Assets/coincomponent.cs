using UnityEngine;

public class coincomponent : MonoBehaviour
{
    private float Bank;

    public delegate void OnCoinChangeHandler(float newBank, float amountChange);
    public event OnCoinChangeHandler OnCoinChange;

    public delegate void OnCoinInitializedHandler(float Bank);
    public event OnCoinInitializedHandler OnCoinInitialized;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Bank = 0;
        OnCoinInitialized?.Invoke(Bank);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddCoin(float Coin)
    {
        Bank += Coin;
        //Debug.Log(Bank);
     
       OnCoinInitialized?.Invoke(Coin);
       
       // if (Bank == 3)
       // {
        //    Debug.Log("heal");
        //}
    }
}
