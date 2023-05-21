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
    // Start is called before the first frame update
    void Start()
    {
    }
    
    void loadHighscoores()
    {
        //TODO skapa lista som sparas någonstans och som är sorterad.
        //#Med namn och  score
        //Töm listan
        string[] names = { "Petra", "JAg", "ks", "dss" };
        for(int i  = 0; i < names.Length; i++) 
        {
            GameObject newText = Instantiate(prefab, scrollViewContent);
            newText.transform.Find("name").GetComponent<TMPro.TextMeshProUGUI>().text = i+1+". "+names[i];
            newText.transform.Find("score").GetComponent<TMPro.TextMeshProUGUI>().text = "" + 0;
        }
    }

    public void OpenHighscoore()
    {
        StartFrame.gameObject.SetActive(false);
        loadHighscoores();
        HighScore.gameObject.SetActive(true);
    }
    public void CloseHighscoore()
    {
        StartFrame.gameObject.SetActive(true);
        HighScore.gameObject.SetActive(false);
    }

    public void startGame(string scenname)
    {
        SceneManager.LoadScene(scenname);
    } 
    public void endGame()
    {
        Application.Quit();
        Debug.Log("Avsluta spelet");
    }
}
