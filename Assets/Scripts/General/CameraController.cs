using System.Collections.Generic;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;
    Transform player;
    public List<GameObject> Backgrounds;
    public AudioClip MainTheme;
    public AudioClip IntroTheme;
    public GameObject Eeveon;
    bool changeMusic = false;

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
        Backgrounds = new List<GameObject>();
        player = GameObject.Find("Eeveeon").transform;
        //SceneManager.sceneLoaded += HandleSceneLoaded;
        Invoke("MusicChange", 2.925f);
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Eeveeon").transform;
        transform.position = new Vector3 (player.position.x, transform.position.y, -10);

       // DontDestroyOnLoad(gameObject);

    }


    /*void HandleSceneLoaded(Scene scene, LoadSceneMode mode){
        //do your scene logic by doing scene.name
        print(scene.name.ToString() + "Current") ;
        foreach(var item in Backgrounds){
            Destroy(item);
        }
        Backgrounds.Clear();

        /*if (scene.name == "Winscreen" || scene.name == "Menu")
        {
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().clip = IntroTheme;
            changeMusic = true;
        }
        if (scene.name == "FuseScene" && changeMusic)
        {
            GetComponent<AudioSource>().Play();
            Invoke("MusicChange", 2.925f);
        }
    }*/
    private void MusicChange()
    {
        GetComponent<AudioSource>().clip = MainTheme;
        GetComponent<AudioSource>().Play();
    }

    public void PlayerFind()
    {
        player = GameObject.Find("Eeveeon").transform;
    }
    /*private void OnDisable()
    {
        SceneManager.sceneLoaded -= HandleSceneLoaded;

    }*/
}
