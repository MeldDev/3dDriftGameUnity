using UnityEngine.SceneManagement;

public class SceneLoader : IService
{
    public string sceneToLoad;
    public string intermediateSceneName = "IntermediateScene";
    public void LoadSceneWithProgressBar(string nextScene)
    {
        sceneToLoad = nextScene;
        SceneManager.LoadScene(intermediateSceneName);
    }
    public void LoadScene(string nextScene)
    {
        sceneToLoad = nextScene;
        SceneManager.LoadScene(sceneToLoad);
    }
    public void SetNextScene(string nextScene)
    {
        sceneToLoad = nextScene;
    }
}
