using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class BaseEnemy : MonoBehaviour
{
    [SerializeField] private int _MaxHealth = 0;
    [SerializeField] private float _Speed = 1.0f;
    [SerializeField] private int _BaseContactDamage = 1;

    private Health _health;
    private float _scale;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _health.SetMaxHealth(_MaxHealth);
        _scale = transform.localScale.x;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, GameConstants.playerTransform.transform.position, _Speed * Time.fixedDeltaTime);
        pos.y = transform.position.y;
        transform.position = pos;
        if (transform.position.x < GameConstants.playerTransform.transform.position.x)
        {
            transform.localScale = new Vector3(_scale, _scale, _scale);
        }
        else
        {
            transform.localScale = new Vector3(-_scale, _scale, _scale);
        }
    }

    public int GetContactDamage()
    {
        return (_BaseContactDamage);
    }
}
