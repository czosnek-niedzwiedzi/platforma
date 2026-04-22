using UnityEngine;
using TMPro;
using System;

public class UI_CoiunDisplay : MonoBehaviour
{
    public coincomponent coincomponent;
    public TextMeshProUGUI textComponent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coincomponent.OnCoinInitialized += OnCoinInitialized;
        coincomponent.OnCoinChange += OnCoinChange;
    }

    private void OnCoinChange(float newBank, float amountChange)
    {
        //Debug.Log(newBank + ":" + amountChange);
        textComponent.text = newBank.ToString();
    }

    private void OnCoinInitialized(float Bank)
    {
        textComponent.text = Bank.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
