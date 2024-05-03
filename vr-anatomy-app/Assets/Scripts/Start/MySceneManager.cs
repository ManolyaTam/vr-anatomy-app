using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeScene(string sceneName)
    {
        // Load the new scene
        SceneManager.LoadScene(sceneName);
    }


    public void addSceneAdditive(string sceneName) // use when you want to add a scene on top of the current ones
    {
        // Load the new scene additively
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void changeSceneAdditive(string sceneName) // use when you want to load one scene only on top of "Start"
    {
        // Load "Start" scene
        SceneManager.LoadScene("Start"); // back to start and unload all other scenes

        // Load the new scene additively
        //SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);

        // Load the new scene additively asynchronously
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive).completed += operation =>
        {
            // Hide the start canvas after the new scene is loaded
            HideStartCanvas();
        };
    }

    public void resetScene() // exit current scene and only load "Start" scene
    {
        // Load "Start" scene
        SceneManager.LoadScene("Start");
    }

    public void HideStartCanvas()
    {
        // Find the canvas GameObject in the "Start" scene and deactivate it
        Scene startScene = SceneManager.GetSceneByName("Start");
        if (startScene.IsValid())
        {
            GameObject[] rootObjects = startScene.GetRootGameObjects();
            foreach (GameObject obj in rootObjects)
            {
                if (obj.name == "Canvas")
                {
                    obj.SetActive(false);
                    Debug.Log("Start canvas deactivated.");
                    return; // Stop searching once the canvas is found and deactivated
                }
            }
        }
        else
        {
            Debug.LogWarning("Start scene not found.");
        }
    }
}
