using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton : MonoBehaviour
{
    public static Singleton instance;

    public int sceneChanges = 0;

    public void Awake() 
    {
        if (instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        else 
        {
            if (instance != this) 
            {
                Destroy(gameObject);
            }
        }
    }

    public void Update() 
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            LoadNextScene();
            Debug.Log(sceneChanges);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            LoadPreviousScene();
            Debug.Log(sceneChanges);
        }
    }

    void LoadNextScene() 
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        sceneChanges += 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    void LoadPreviousScene() 
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int previousSceneIndex = (currentSceneIndex - 1 + SceneManager.sceneCountInBuildSettings) % SceneManager.sceneCountInBuildSettings;
        sceneChanges += 1;
        SceneManager.LoadScene(previousSceneIndex);
    }
}
