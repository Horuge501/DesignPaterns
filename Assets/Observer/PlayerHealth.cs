using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private List<IObserver> observers = new List<IObserver>();

    private void Start() 
    {
        currentHealth = maxHealth;
    }

    public void AddObserver(IObserver observer) 
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer) 
    {
        observers.Remove(observer);
    }

    private void NotifyObservers() 
    {
        foreach (var observer in observers) 
        {
            observer.OnNotify(currentHealth);
        }
    }

    public void TakeDamage(int damage) 
    {
        currentHealth -= damage;
        if (currentHealth < 0) 
        {
            currentHealth = 0;
        }
        NotifyObservers();
    }

    public void Heal(int amount) 
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) 
        {
            currentHealth = maxHealth;
        }
        NotifyObservers();
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            TakeDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.H)) 
        {
            Heal(10);
        }
    }
}
