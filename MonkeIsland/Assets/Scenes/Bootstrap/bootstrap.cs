using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class bootstrap : MonoBehaviour
{
    public GameObject backToSceneExamples;

    // Start is called before the first frame update
    void Start()
    {
        // https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html
        DontDestroyOnLoad(backToSceneExamples);
        SceneManager.LoadScene("SceneExamples");
    }
}
