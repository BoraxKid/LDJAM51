using UnityEngine;

public class SetTargetFramerate : MonoBehaviour
{
    [SerializeField][Range(0, 144)] private int _targetFrameRate = 30;

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = _targetFrameRate;
    }

    private void Update()
    {
        if (Application.targetFrameRate != _targetFrameRate)
        {
            if (_targetFrameRate == 0)
            {
                QualitySettings.vSyncCount = 1;
            }
            else
            {
                QualitySettings.vSyncCount = 0;
            }
            Application.targetFrameRate = _targetFrameRate;
        }
    }
}
