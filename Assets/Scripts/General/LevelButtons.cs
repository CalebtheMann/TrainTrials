using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtons : MonoBehaviour
{
    GameController controller;
    public TMP_Text ContinueText;
    public int Level;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void GameStart()
    {
        controller.Segmented = false;
        SceneManager.LoadScene("Cutscene");
    }
    public void LevelStart()
    {
        controller.CurrentCar = Level;
        controller.Segmented = true;
        SceneManager.LoadScene("BetaCars");
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ToTheResults()
    {
        SceneManager.LoadScene("The End");
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelMenu");
    }

    public void SaveDataDelete()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
        SceneManager.LoadScene("The End");
    }
}
