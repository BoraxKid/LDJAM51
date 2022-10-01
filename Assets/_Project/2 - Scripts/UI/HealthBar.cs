using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    private Camera _camera;
    private Slider _slider;
    private Health _playerHealth;

    private RectTransform _rectTransform;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        _camera = Camera.main;
        _playerHealth = GameConstants.player.GetComponent<Health>();
    }

    private void LateUpdate()
    {
        _slider.value = (float)_playerHealth.CurrentHealth / _playerHealth.MaxHealth;

        //Vector3 targPos = GameConstants.player.transform.position + new Vector3(0.0f, 2.0f, 0.0f);
        //Vector3 camForward = _camera.transform.forward;
        //Vector3 camPos = _camera.transform.position + camForward;
        //float distInFrontOfCamera = Vector3.Dot(targPos - camPos, camForward);
        //if (distInFrontOfCamera < 0f)
        //{
        //    targPos -= camForward * distInFrontOfCamera;
        //}
        //_rectTransform.position = RectTransformUtility.WorldToScreenPoint(_camera, GameConstants.player.transform.position);
    }
}
