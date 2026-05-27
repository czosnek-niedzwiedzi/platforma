using TMPro;
using UnityEngine;

public class dashUI : MonoBehaviour
{
    public Playermotor playermotor;
    public TextMeshProUGUI textComponent;
    void Start()
    {
        playermotor.OnDashInitialized += OnDashInitialized;

    }
    private void OnDashInitialized(float dashbar)
    {
        textComponent.text = dashbar.ToString();
    }
    
}
