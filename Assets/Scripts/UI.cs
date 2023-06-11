using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UI : MonoBehaviour
{
    [SerializeField] private Transform scrollViewContent;
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject StartFrame;
    [SerializeField] private GameObject HighScore;
    [SerializeField] private GameObject Scriptobject;


    /*----------------Highscore----------------*/
    public List<HighScoreEntry> highscores;
    void Start()
    {
        highscores = Scriptobject.GetComponent<XMLHandler>().LoadScores();
    }
    void loadHighscore()
    {
        for (int i  = 0; i < highscores.Count; i++) 
        {
            GameObject newText = Instantiate(prefab, scrollViewContent);
            newText.transform.Find("name").GetComponent<TMPro.TextMeshProUGUI>().text = i + 1 +". " + highscores[i].name;
            newText.transform.Find("score").GetComponent<TMPro.TextMeshProUGUI>().text = "" + highscores[i].highscore;
        }
    }
    void clearHighscoreBorad()
    {
        foreach (Transform child in scrollViewContent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
    public void AddHighscore(String name, int newValue)
    {
        highscores.Add(new HighScoreEntry(name, newValue));
        SaveHighscore();
    }
    public void SaveHighscore()
    {
        highscores.Sort();
        Scriptobject.GetComponent<XMLHandler>().SaveScores(highscores);
    }
    public void CloseHighscore()
    {
        StartFrame.gameObject.SetActive(true);
        HighScore.gameObject.SetActive(false);
        clearHighscoreBorad();
    }

    /*----------------Buttons----------------*/
    public void startGame(string scenname)
    {
        SceneManager.LoadScene(scenname);
    }
    public void OpenHighscoore()
    {
        StartFrame.gameObject.SetActive(false);
        loadHighscore();
        HighScore.gameObject.SetActive(true);
    }
    public void endGame()
    {
        SaveHighscore();
        Application.Quit();
        Debug.Log("Avsluta spelet");
    }
}






