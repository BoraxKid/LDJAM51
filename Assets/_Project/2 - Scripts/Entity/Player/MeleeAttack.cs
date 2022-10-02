using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private MeleeCollider _leftCollider;
    [SerializeField] private MeleeCollider _rightCollider;
    [SerializeField] private float _attackTiming = 1.0f;
    [SerializeField] private Animator _leftAnim;
    [SerializeField] private Animator _rightAnim;

    private float _attackElapsedTime = 0.0f;

    private int GetMeleeDamage()
    {
        return (1);
    }

    private void Update()
    {
        _attackElapsedTime += Time.deltaTime;
        if (_attackElapsedTime >= _attackTiming)
        {
            _attackElapsedTime = 0.0f;
            Attack();
        }
    }

    public void Attack()
    {
        MeleeCollider collider = null;
        Animator animation = null;
        float x = 1.0f;
        if (_spriteRenderer.flipX)
        {
            collider = _leftCollider;
            animation = _leftAnim;
            x = -1.0f;
        }
        else
        {
            collider = _rightCollider;
            animation = _rightAnim;
        }
        for (int i = 0; i < collider.Colliders.Count; i++)
        {
            BaseEnemy enemy = collider.Colliders[i].GetComponent<BaseEnemy>();
            if (enemy != null)
            {
                enemy.Hit(GetMeleeDamage(), new Vector3(x, 0.0f, 0.0f));
            }
        }
        animation.ResetTrigger("Hit");
        animation.Play("Hit");
    }
}
