using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class BackToSceneExamples : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButton("Util0"))
        {
            StartCoroutine(LoadYourAsyncScene());
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SceneExamples");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
