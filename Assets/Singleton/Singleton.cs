using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton : MonoBehaviour
{
    // Variable est�tica que contiene la instancia �nica de la clase
    public static Singleton instance;

    // Contador para demostraci�n que guarda la informaci�n entre escenas
    public int sceneChanges = 0;

    public void Awake() 
    {
        // Si no existe una instancia previa del Singleton, se asigna esta como la �nica instancia
        if (instance == null) 
        {
            instance = this;
            // Evita que el objeto sea destruido al cambiar de escena
            DontDestroyOnLoad(gameObject);
        } 
        else 
        {
            // Si ya existe una instancia, este objeto se autodestruye
            if (instance != this) {
                Destroy(gameObject);
            }
        }
    }

    public void Update() {
        // Si se presiona la tecla de flecha derecha, se carga la siguiente escena
        if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            LoadNextScene();
            // Imprime la cantidad de cambios de escena realizados
            print(sceneChanges);
        }
        // Si se presiona la tecla de flecha izquierda, se carga la escena anterior
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            LoadPreviousScene();
            // Imprime la cantidad de cambios de escena realizados
            print(sceneChanges);
        }
    }

    // M�todo que carga la siguiente escena en el �ndice de build settings
    void LoadNextScene() 
    {
        // Obtiene el �ndice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Calcula el �ndice de la siguiente escena, haciendo un ciclo si llega al final
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        // Incrementa el contador de cambios de escena
        sceneChanges += 1;
        // Carga la siguiente escena
        SceneManager.LoadScene(nextSceneIndex);
    }

    // M�todo que carga la escena anterior en el �ndice de build settings
    void LoadPreviousScene() 
    {
        // Obtiene el �ndice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Calcula el �ndice de la escena anterior, haciendo un ciclo si llega al principio
        int previousSceneIndex = (currentSceneIndex - 1 + SceneManager.sceneCountInBuildSettings) % SceneManager.sceneCountInBuildSettings;
        // Incrementa el contador de cambios de escena
        sceneChanges += 1;
        // Carga la escena anterior
        SceneManager.LoadScene(previousSceneIndex);
    }
}
