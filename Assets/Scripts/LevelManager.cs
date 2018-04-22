using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
    {
            if (SceneManager.GetActiveScene().name == "scene2")
            {
                SceneManager.LoadScene("scene1", LoadSceneMode.Single);
            }
        SceneManager.LoadScene(name);
    }

    public void EndGame()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }
}

