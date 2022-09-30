using UnityEngine;

public class ChangeSceneButton : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneLoader.Instance.Load(sceneName);
    }
}
