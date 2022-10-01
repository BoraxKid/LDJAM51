using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image _image = null;
    [SerializeField] private TMPro.TextMeshProUGUI _text = null;
    [SerializeField] private EnemySpawner _enemySpawner = null;

    private void Update()
    {
        _text.SetText(Mathf.Ceil(_enemySpawner.GetRemainingTime()).ToString("0"));
        _image.fillAmount = _enemySpawner.GetRemainingTime() / _enemySpawner.GetMaxTime();
    }
}
