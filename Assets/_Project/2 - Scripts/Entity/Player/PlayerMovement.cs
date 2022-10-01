using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1.0f;

    private CharacterController _characterController;
    private Vector3 _movement;
    private Vector2 _movementInput;

    private void Awake()
    {
        if (GameConstants.player == null)
        {
            GameConstants.player = gameObject;
        }
        //if (_cameraTransform == null)
        //{
        //    if (Camera.main)
        //        _cameraTransform = Camera.main.transform;
        //    else
        //        Debug.LogError("No main camera");
        //}
        _characterController = GetComponent<CharacterController>();

        //_variable.gameObject = gameObject;
        //_variable.collider = GetComponentInChildren<Collider>();
        //_variable.isAlive = true;
        //_variable.isGrounded = true;
        //_variable.isCrouched = false;
        //_variable.movement = Vector3.zero;
        //_variable.velocity = Vector3.zero;
        //_variable.brightness = 0.0f;
        //GameConstants.playerVariable = _variable;
    }

    private void Update()
    {
        HandleInputs();
        ComputeCameraRelativeMovement();
        CharacterControllerMovement();
    }

    private void FixedUpdate()
    {
        //ComputeCameraRelativeMovement();
        //CharacterControllerMovement();
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
    }

    private void CharacterControllerMovement()
    {
        _characterController.Move(_movement * Time.deltaTime);
        Vector3 tmp = _movement;
        tmp.y = 0;
        if (tmp == Vector3.zero)
            return;
        transform.rotation = Quaternion.LookRotation(tmp, Vector3.up);
    }


}
