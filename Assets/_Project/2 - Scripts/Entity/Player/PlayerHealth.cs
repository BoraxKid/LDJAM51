using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Collider))]
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _MaxHealth = 0;

    private Health _health = null;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _health.SetMaxHealth(_MaxHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        ContactHit(other.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        ContactHit(other.gameObject);
    }

    private void ContactHit(GameObject gameObject)
    {
        BaseEnemy enemy = gameObject.GetComponent<BaseEnemy>();
        if (enemy != null)
        {
            _health.Decrease(enemy.GetContactDamage());
        }
    }
}
