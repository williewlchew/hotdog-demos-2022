using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

public class RaycastUi : MonoBehaviour
{
    public VisualElement visualElement;
    private IPanel panel;

    // Start is called before the first frame update
    void Start()
    {
        panel = visualElement.panel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
