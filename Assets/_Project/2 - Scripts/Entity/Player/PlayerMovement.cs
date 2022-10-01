using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _moveSpeed = 1.0f;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Rigidbody _characterRigidbody;
    private Vector3 _movement;
    private Vector2 _movementInput;

    private void Awake()
    {
        if (GameConstants.player == null)
        {
            GameConstants.player = gameObject;
        }
        if (GameConstants.playerTransform == null)
        {
            GameConstants.playerTransform = _target;
        }

        _characterRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleInputs();
        if (_movementInput.x != 0.0f)
        {
            _spriteRenderer.flipX = _movementInput.x < 0.0f;
        }
    }

    private void FixedUpdate()
    {
        ComputeCameraRelativeMovement();
        CharacterControllerMovement();
    }

    private void HandleInputs()
    {
        _movementInput.x = Input.GetAxis("Horizontal");
        _movementInput.y = Input.GetAxis("Vertical");
    }

    private void ComputeCameraRelativeMovement()
    {
        _movement = _movementInput.y * Vector3.forward + _movementInput.x * Vector3.right;
        if (_movement.magnitude > 1) // Make sure we don't go faster when going diagonally
            _movement.Normalize();
        _movement *= _moveSpeed;
        _movement.y = 0.0f;
    }

    private void CharacterControllerMovement()
    {
        _characterRigidbody.MovePosition(_characterRigidbody.transform.position + _movement * Time.deltaTime);
    }


}
