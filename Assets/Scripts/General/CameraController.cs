using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;
    Transform player;
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
        player = GameObject.Find("Eeveeon").transform;
        SceneManager.sceneLoaded += HandleSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (player.position.x, transform.position.y, -10);
       // DontDestroyOnLoad(gameObject);

    }


    //first scene is what we're in now, second scene is the next one
    void HandleSceneLoaded(Scene scene, LoadSceneMode mode){
        //do your scene logic by doing scene.name
        print(scene.name.ToString() + "Current") ;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= HandleSceneLoaded;

    }
}
