using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthScript : MonoBehaviour
{
    [SerializeField]
    private int currentHealth, maxHealth;

    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    [SerializeField]
    public static bool isDead = false;

    public void InitializeHealth(int helathValue) 
    {
        currentHealth = helathValue;
        maxHealth = helathValue;
        isDead = false;
    }

    public void GetHit(int amount, GameObject sender) 
    {
        if (isDead)
            return;
        if (sender.tag == gameObject.tag)
            return;

        currentHealth -= amount;

        if (currentHealth > 0)
        {
            OnHitWithReference?.Invoke(sender);
        }
        else 
        {
            OnDeathWithReference?.Invoke(sender);
            isDead = true;
            Destroy(gameObject);
        }

        if (isDead) 
        {
            Debug.Log("You are dead");
        }
    }
}
