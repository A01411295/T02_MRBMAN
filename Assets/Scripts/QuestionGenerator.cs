using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class QuestionGenerator : MonoBehaviour {
    public Text question;
    public Text answer1;
    public Text answer2;
    public Text answer3;
    public Text result;
    public LambMovement lamb;
    static List<int> listNumbers;
    static LevelManager levelManager = new LevelManager();

    string[,] cuestionario = { {"¿Cual ley de newton es la de reaccion?", "Primera", "Segunda", "Tercera" },
        {"¿Con que formula obtienes el campo magnetico?", "a=mg", "ya no se", "pregunta mal 2"  } };
    // Use this for initialization
    void Start () {
        int pregunta = UnityEngine.Random.Range(0, cuestionario.GetLength(0));
        question.text = cuestionario[pregunta, 0];

        List<int> possible = Enumerable.Range(1, 3).ToList();
        int pCount = possible.Count;
        listNumbers = new List<int>();
        for (int i = 0; i < pCount; i++)
        {
            int index = UnityEngine.Random.Range(0, possible.Count);
            Debug.Log("index: " + index);
            listNumbers.Add(possible[index]);
            possible.RemoveAt(index);
        }
        Debug.Log("listNumbers: " + listNumbers.Count);
        answer1.text = cuestionario[pregunta, listNumbers[0]];
        answer2.text = cuestionario[pregunta, listNumbers[1]];
        answer3.text = cuestionario[pregunta, listNumbers[2]];

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Answer(int answer)
    {
        if(listNumbers[answer] == 1)
        {
            result.text = "Felicidades que inteligente";
            lamb.answerQuestion(1);
        }
        else
        {
            result.text = "No estudiaste lo suficiente";
            lamb.answerQuestion(0);
        }

        Invoke("returnScene", 1);
          
    }
    public void returnScene()
    {
        levelManager.returnToScene();
    }
}
