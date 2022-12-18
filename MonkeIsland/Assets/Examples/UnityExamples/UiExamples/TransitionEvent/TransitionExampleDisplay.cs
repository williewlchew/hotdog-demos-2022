using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

public class TransitionExampleDisplay : MonoBehaviour
{
    private TransitionExample example;

    private void OnEnable()
    {
        UIDocument menu = GetComponent<UIDocument>();
        VisualElement root = menu.rootVisualElement;

        // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/new-operator
        example = new(root); 

        example.CreateGUI();
    }
}
