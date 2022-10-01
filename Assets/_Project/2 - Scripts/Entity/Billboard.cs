using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform _cameraTransform;

    private void Start()
    {
        _cameraTransform = Camera.main.transform;
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + _cameraTransform.forward);
    }
}
