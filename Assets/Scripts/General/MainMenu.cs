using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("LevelMenu");
    }
    public void EndGame()
    {
        Application.Quit();
    }
}
