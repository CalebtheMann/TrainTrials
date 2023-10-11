using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    GameController gameController;
    /// private Menus input;
    InputActionAsset inputAsset;
    InputActionMap inputMap;
    InputAction play;

    private void Awake()
    {
        inputAsset = this.GetComponent<PlayerInput>().actions;
        inputMap = inputAsset.FindActionMap("Menu");
        play = inputMap.FindAction("PlayGame");
        play.performed += ctx => StartGame();
    }
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        if (GameObject.Find("Eeveeon") != null)
        {
            Destroy(GameObject.Find("Eeveeon"));
        }
        gameController = GetComponent<GameController>();
    }
    
    public void FixedUpdate()
    {

    }
    public void StartGame()
    {
        SceneManager.LoadScene("FuseScene");
        //gameController.ToTheFuse();
    }
    public void EndGame()
    {
        Application.Quit();
    }
    
    private void OnEnable()
    {
        inputMap.Enable();
    }

    private void OnDisable()
    {
        inputMap.Disable();
    }
}
