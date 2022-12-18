using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    void Update()
    {
        int sceneKey = 0;
        
        if (Input.GetButton("Util1"))
        {
            sceneKey = 1;
        }
        
        if (Input.GetButton("Util2"))
        {
            sceneKey = 2;
        }

        if (sceneKey != 0)
        {
            // Use a coroutine to load the Scene in the background
            StartCoroutine(LoadYourAsyncScene(sceneKey));
        }
    }

    IEnumerator LoadYourAsyncScene(int sceneKey)
    {
        string sceneName = "";
        switch(sceneKey){
            case 1:
                sceneName = "UiExamples";
                break;
            case 2:
                sceneName = "NavMeshExamples";
                break;
            default:
                // code block
                break;
        }

        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}