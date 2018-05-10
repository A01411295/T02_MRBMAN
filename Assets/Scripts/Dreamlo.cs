using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Dreamlo : MonoBehaviour
{
    static int points;//add this value to AddNewHighscore function
    static string user;//& this you can replace it with string from input field
    public Text anzeige;
    public Text usrLbl;
    public Text scoreLbl;
    public bool setScore = true;
    public bool isScoreboard = false;

    LevelManager levelManager;
    const string privateCode = "Nz6u5ClHyEqyIxiIsnmbIAg-rf1y7ooUGGpv-KENq3Xg";
    const string publicCode = "5ae11457191a840bcc94f650";
    const string webURL = "http://dreamlo.com/lb/";
    public Highscore[] highscoresList;

    void Awake()
    {
        if(isScoreboard)
        {
            DownloadHighscores();
        }
        //call this function to upload & put your variables inside braces 
        //AddNewHighscore(user, points);
        //  DownloadHighscores();// & this to download
    }
  
    void Update()
    {
        if(setScore)
        {
            points = System.Convert.ToInt32(scoreLbl.text);
            Debug.Log("" + points);
            setScore = false;
        }
        
        if(!isScoreboard)
        {
            if (user != usrLbl.text)
            {
                user = usrLbl.text;
            }
        }
        
        
    }

    public void AddNewHighscore()
    {
        StartCoroutine(UploadNewHighscore(user, points));
        
    }

    IEnumerator UploadNewHighscore(string username, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;
        if (string.IsNullOrEmpty(www.error))
            print("Upload Successful");
        else
        {
            print("Error uploading: " + www.error);
        }
        levelManager = new LevelManager();
        levelManager.LoadLevel("menu");
    }

    public void DownloadHighscores()
    {
        StartCoroutine("DownloadHighscoresFromDatabase");
    }
    IEnumerator DownloadHighscoresFromDatabase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;
        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighscores(www.text);
        }
        else
        {
            print("Error Downloading: " + www.error);
        }
    }
    void FormatHighscores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entries.Length];
        for (int i = 0; i < 8; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoresList[i] = new Highscore(username, score);
            print(highscoresList[i].username + ": " + highscoresList[i].score);
            //this line will change the ui text 
            anzeige.text += (highscoresList[i].username + ": " + highscoresList[i].score + "\n");
        }
    }
}
public struct Highscore
{
    public string username;
    public int score;
    public Highscore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }
}