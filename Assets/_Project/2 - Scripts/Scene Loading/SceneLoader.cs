using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    [SerializeField] private GameObject _loaderCanvas;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }

    public void Load(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        _loaderCanvas.SetActive(true);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;

        // Wait until the asynchronous scene fully loads
        while (asyncLoad.progress < 0.9f)
        {
            yield return null;
        }
        asyncLoad.allowSceneActivation = true;
        _loaderCanvas.SetActive(false);
    }
}
