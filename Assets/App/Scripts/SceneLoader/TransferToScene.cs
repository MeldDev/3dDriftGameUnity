using UnityEngine;
using UnityEngine.UI;

public class TransferToScene : MonoBehaviour
{
    [SerializeField] private string toScene;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(()=>
        {
            OpenScene();
        });
    }
#if UNITY_ANDROID
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenScene();
        }
    }
#endif

#if UNITY_IOS
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void OpenNewSceneiOS();

    private void Update()
    {
        if (IsBackPressediOS())
        {
            OpenScene();
        }
    }

    private bool IsBackPressediOS()
    {
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
    }
#endif

    private void OpenScene()
    {
        //BootstrapEntryPoint.instance._serviceLocator.Get<SceneLoader>().LoadSceneWithProgressBar(toScene);
    }
}
