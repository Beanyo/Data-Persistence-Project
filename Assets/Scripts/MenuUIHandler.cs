using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{

    public string currentPlayerName;
    public string highPlayerName;
    public GameObject inputFieldObj;
    public Text ScoreText;
    public int highScore;


    public void Start()
    {
        MenuManager.Instance.LoadScore();
        highScore = MenuManager.Instance.highScore;
        highPlayerName = MenuManager.Instance.highPlayerName;
        UpdateBestScore();
    }
    public void GetPlayerName()
    {
        InputField inputField = inputFieldObj.GetComponent<InputField>();
        currentPlayerName = inputField.text;
        if (string.IsNullOrEmpty(currentPlayerName))
        {
            return;
        }
        MenuManager.Instance.currentPlayerName = currentPlayerName;
        Debug.Log(currentPlayerName);
    }

    public void UpdateBestScore()
    {
        ScoreText.text = "Best Score: " + highPlayerName + " : " + highScore;
        Debug.Log(highPlayerName + highScore);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ResetBest()
    {
        highPlayerName = "None";
        highScore = 0;
        UpdateBestScore();
        MenuManager.Instance.currentPlayerName = highPlayerName;
        MenuManager.Instance.highScore = highScore;
        MenuManager.Instance.SaveScore();
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
