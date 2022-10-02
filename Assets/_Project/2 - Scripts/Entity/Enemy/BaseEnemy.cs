using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class BaseEnemy : MonoBehaviour
{
    [SerializeField] private int _MaxHealth = 0;
    [SerializeField] private float _Speed = 1.0f;
    [SerializeField] private int _BaseContactDamage = 1;
    [SerializeField] private SphereCollider _triggerCollider;

    public bool Alive { get; private set; } = true;

    private Health _health;
    private Rigidbody _rigidbody;
    private float _scale;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _health.SetMaxHealth(_MaxHealth);
        _rigidbody = GetComponent<Rigidbody>();
        _scale = transform.localScale.x;
    }

    private void FixedUpdate()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, GameConstants.playerTransform.transform.position, _Speed * Time.fixedDeltaTime);
        pos.y = transform.position.y;
        //transform.position = pos;
        _rigidbody.MovePosition(pos);
        if (transform.position.x < GameConstants.playerTransform.transform.position.x)
        {
            transform.localScale = new Vector3(_scale, _scale, _scale);
        }
        else
        {
            transform.localScale = new Vector3(-_scale, _scale, _scale);
        }
    }

    public void Hit(int damage, Vector2 hitDirection)
    {
        _health.Decrease(damage);
    }

    public void Die()
    {
        Alive = false;
        //transform.Translate(Vector3.down * 10.0f);
        //_triggerCollider.radius = 0.0f;
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public int GetContactDamage()
    {
        return (_BaseContactDamage);
    }
}
