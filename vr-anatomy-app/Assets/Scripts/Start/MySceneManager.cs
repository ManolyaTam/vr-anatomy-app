using System.Collections;
using System.Collections.Generic;
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
        SceneManager.LoadScene(sceneName);
    }


    public void addSceneAdditive(string sceneName) // use when you want to add a scene on top of the current ones
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void changeSceneAdditive(string sceneName) // use when you want to load one scene only on top of "Start"
    {
        SceneManager.LoadScene("Start"); // back to start and unload all other scenes
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void resetScene() // exit current scene and only load "Start" scene
    {
        SceneManager.LoadScene("Start");
    }
}   
