using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private MeleeCollider _leftCollider;
    [SerializeField] private MeleeCollider _rightCollider;

    public void Attack()
    {
        if (_spriteRenderer.flipX)
        {

        }
        else
        {

        }
    }
}
