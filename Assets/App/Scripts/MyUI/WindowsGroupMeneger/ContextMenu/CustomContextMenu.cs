using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CustomEditor(typeof(Canvas))]
public class CustomContextMenu : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Canvas canvas = (Canvas)target;

        if (GUILayout.Button("Открыть новое окно"))
        {
            // Здесь вызовите метод вашего менеджера окон для открытия нового окна
        }
    }
}
