using System;
using UnityEditor;
using UnityEngine;
using TMPro;

public class UI_HealthDisplay : MonoBehaviour
{
    public HealthComponent healthComponent;
    public TextMeshProUGUI textComponent;
    void Start()
    { 
        healthComponent.OnHealthInitialized += OnHealthInitialized;
        healthComponent.OnHealthChange += OnHealthChange;
    }

    private void OnHealthInitialized(float HP)
    {

        textComponent.text = HP.ToString();
    }

    private void OnHealthChange(float newHealth, float amountChange)
    {
       Debug.Log (newHealth + ":" + amountChange);
       textComponent.text = newHealth.ToString();
    }
}
