using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int health;

    [SerializeField] private HeartBar heartBar;

    private void Start()
    {
        health = maxHealth;
        heartBar.SetMaxHealth(maxHealth);
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
    public void SetHealth(int value)
    {
        health = Mathf.Clamp(value, 0, maxHealth);
        heartBar.SetHealth(health);
    }
    public void TakeDamage(int damage)
    {
        SetHealth(health - damage);
    }
    public void Heal(int amount)
    {
        SetHealth(health + amount);
    }
}
