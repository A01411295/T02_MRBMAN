using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    static string currentScene ="";
    static bool answer = true;
    public void LoadLevel(string name)
    {
            
        SceneManager.LoadScene(name);
    }
    public void loadQuestion(){
        currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("question", LoadSceneMode.Additive);
    }
    public void returnToScene(){
        SceneManager.UnloadScene("question");
    }

    public void EndGame()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }
}

