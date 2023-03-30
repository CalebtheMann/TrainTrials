using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        if(GameObject.Find("Eeveeon") != null)
        {
            Destroy(GameObject.Find("Eeveeon"));
        }
        gameController = GetComponent<GameController>();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("FuseScene");
    }
    public void EndGame()
    {
        Application.Quit();
    }
}
