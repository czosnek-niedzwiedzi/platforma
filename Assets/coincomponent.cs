using UnityEngine;

public class coincomponent : MonoBehaviour
{
    private float Bank;

  
    public delegate void OnCoinInitializedHandler(float Bank);
    public event OnCoinInitializedHandler OnCoinInitialized;
   
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
     
       OnCoinInitialized?.Invoke(Bank);
       
        if (Bank == 3)
        {
            Debug.Log("heal");
        }
    }
}
