using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    //Times to remember
    public float BestTime1 = 0;
    public float BestTime2 = 0;
    public float BestTime3 = 0;
    public float BestTime4 = 0;
    public float BestTime5 = 0;
    public float BestTime6 = 0;
    public float BestTime7 = 0;
    public float BestTime = 0;
    public float TimerTime;
    public bool Paused = false;
    public bool Segmented = false;
    public int CurrentCar;
    public int UsedGUN = 0;
    AudioSource monkey;
    bool songPlaying = false;
    public AudioClip Rip;
    GameObject player;
    PlayerBehavior behavior;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        monkey = GetComponent<AudioSource>();
        BestTime1 = PlayerPrefs.GetFloat("1");
        BestTime2 = PlayerPrefs.GetFloat("2");
        BestTime3 = PlayerPrefs.GetFloat("3");
        BestTime4 = PlayerPrefs.GetFloat("4");
        BestTime5 = PlayerPrefs.GetFloat("5");
        BestTime6 = PlayerPrefs.GetFloat("6");
        BestTime7 = PlayerPrefs.GetFloat("7");
        UsedGUN = PlayerPrefs.GetInt("Gun");
    }

    private void Update()
    {
        player = GameObject.Find("Eeveeon");

        if (player == null && !songPlaying)
        {
            //AudioSource.PlayClipAtPoint(monkey, Camera.main.transform.position);
            monkey.Play();
            songPlaying = true;
        }
        else if (player != null)
        {
            monkey.Stop();
            songPlaying = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Pause
        /*if (Input.GetKey(KeyCode.P))
        {
            if (Paused)
            {
                Paused = false;
            }
            else
            {
                Paused = true;
            }
        }*/
        //Restart
        if (ControllerTest.instance.Reset != 0)
        {
            SceneManager.LoadScene("BetaCars");
        }

        //Escape
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }*/
    }
    public void UsingGUN()
    {
        print("UsedGUN");
        UsedGUN = 1;
        PlayerPrefs.SetInt("Gun", UsedGUN);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("LevelMenu");
        CurrentCar = 0;
    }
    public void Ending()
    {
        SceneManager.LoadScene("The End");
        CurrentCar = 0;
    }
}
