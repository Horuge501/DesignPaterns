using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour, IObserver 
{
    public TextMeshProUGUI healthText;
    private PlayerHealth playerHealth;

    private void Start() 
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerHealth.AddObserver(this);
    }

    public void OnNotify(int currentHealth) 
    {
        healthText.text = "Health: " + currentHealth.ToString();
        Debug.Log("La vida cambi� a: " + currentHealth);

        
        if (currentHealth == 0) 
        {
            Debug.Log("La vida est� en 0. El jugador est� muerto.");
        }

        
        else if (currentHealth == playerHealth.maxHealth) 
        {
            Debug.Log("La vida est� al m�ximo.");
        }
    }
}
