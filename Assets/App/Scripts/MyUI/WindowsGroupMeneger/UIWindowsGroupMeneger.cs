using UnityEngine;
using UnityEngine.UI;

public class UIWindowsGroupMeneger : MonoBehaviour
{
    [SerializeField] private GameObject[] _windows;
    [SerializeField] private Button[] _buttons;

    private void Start()
    {
        InitializeWindows();
    }
    private void InitializeWindows()
    {
        if (_windows.Length != 0 && _buttons.Length != 0 && _windows.Length == _buttons.Length)
        {
            for (int i = 0; i < _buttons.Length; i++)
            {
                int number = i;
                _buttons[i].onClick.AddListener(() => OpenWindow(number));
            }
        }  
    }
    private void OpenWindow(int number)
    {
        CloseAllWindows();
        _windows[number].SetActive(true);
    }
    private void CloseAllWindows()
    {
        foreach (var window in _windows)
        {
            window.SetActive(false);
        }
    }
}
