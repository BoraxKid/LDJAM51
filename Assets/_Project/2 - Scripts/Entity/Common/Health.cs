using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private UnityEvent _onHit;
    [SerializeField] private UnityEvent _onDeath;

    public int CurrentHealth { get; private set; } = 0;
    public int MaxHealth { get; private set; } = 0;
    public bool IsAlive { get; private set; } = true;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void SetMaxHealth(int maxHealth)
    {
        MaxHealth = maxHealth;
    }

    public void Decrease(int amount)
    {
        CurrentHealth -= amount;
        _onHit.Invoke();
        NormalizeHealth();
    }

    private void NormalizeHealth()
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
        if (CurrentHealth == 0 && IsAlive)
        {
            IsAlive = false;
            _onDeath.Invoke();
            //gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
}
