using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

public class DragAndDropWindow : MonoBehaviour
{
    private DragAndDropManipulator manipulator;

    private void OnEnable()
    {
        UIDocument menu = GetComponent<UIDocument>();
        VisualElement root = menu.rootVisualElement;

        // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/new-operator
        manipulator = new(root.Q<VisualElement>("object")); // new TabbedMenuController with root as a parameter

        manipulator.RegisterCallbacks();
    }
}