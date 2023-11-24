using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadSceneAsync : MonoBehaviour
{
    [SerializeField] private Image fillLine;
    [SerializeField] private float timeToLoad;
    [SerializeField] private TextMeshProUGUI progressText;
    AsyncOperation operation;
    SceneLoader _SceneManager;
    private void Start()
    {
        //_SceneManager = GameObject.FindFirstObjectByType<BootstrapEntryPoint>()._serviceLocator.Get<SceneLoader>();
        StartCoroutine(LoadSceneWithTime());
        //StartCoroutine(AsyncLoadScene());
    }
    private IEnumerator LoadSceneWithTime()
    {
        StartCoroutine(AsyncLoadScene());
        float time = 0;
        while (time < timeToLoad)
        {
            time += Time.fixedDeltaTime;
            float progress = time / timeToLoad;
            fillLine.fillAmount = progress;
            progressText.text = (progress * 100f).ToString("F0") + "%";
            yield return new WaitForSecondsRealtime(Time.fixedDeltaTime);
        }
        operation.allowSceneActivation = true;
        //SceneManager.LoadScene(GameEngine.instance.SceneManager.sceneToLoad);
    }
    private IEnumerator AsyncLoadScene()
    {
        operation = SceneManager.LoadSceneAsync(_SceneManager.sceneToLoad);
        operation.allowSceneActivation = false;  
/*
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            fillLine.fillAmount = progress;
            progressText.text = (progress * 100f).ToString("F0") + "%";

        }*/
            yield return null;
    }
}
