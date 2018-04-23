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
    public bool returnToScene(){
        SceneManager.UnloadScene("question");
        return answer;
    }

    public void EndGame()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }
}

