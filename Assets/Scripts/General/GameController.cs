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
    AudioSource Title;
    AudioSource LevelIntro;
    AudioSource Level;
    AudioSource Victory;
    AudioSource Credits;
    bool songPlaying = false;
    public AudioClip Rip;
    GameObject player;
    PlayerBehavior behavior;
    GameObject TestDog;

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
        Title = GetComponent<AudioSource>();
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
        TestDog = GameObject.Find("TestDog");

        if (player == null && !songPlaying)
        {
            //AudioSource.PlayClipAtPoint(Title, Camera.main.transform.position);
            Title.Play();
            songPlaying = true;
        }
        else if (player != null)
        {
            Title.Stop();
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
            SceneManager.LoadScene("Menu");
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

    public void ToTheFuse()
    {
        //SceneManager.LoadScene("FuseScene");
        //behavior.Restart();
        if (Camera.main != null)
        {
            CameraController.Instance.GetComponent<AudioSource>().Play();
            CameraController.Instance.Invoke("MusicChange", 2.925f);
            CameraController.Instance.Invoke("PlayerFind", 0.1f);
        }
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        CurrentCar = 7;
        if (Camera.main != null)
        {
            CameraController.Instance.GetComponent<AudioSource>().Stop();
            CameraController.Instance.GetComponent<AudioSource>().clip = CameraController.Instance.IntroTheme;
        }
    }
    public void Ending()
    {
        SceneManager.LoadScene("WinScreen");
        CurrentCar = 0;
        if (Camera.main != null)
        {
            Debug.Log("Stop Music");
            CameraController.Instance.GetComponent<AudioSource>().Stop();
            CameraController.Instance.GetComponent<AudioSource>().clip = CameraController.Instance.IntroTheme;
        }
        Destroy(TestDog);
    }
}
