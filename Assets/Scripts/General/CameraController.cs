using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Eeveeon").transform;
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (player.position.x, transform.position.y, -10);
       // DontDestroyOnLoad(gameObject);
    }
}
