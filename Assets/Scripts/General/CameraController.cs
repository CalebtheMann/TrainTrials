using Unity.VectorGraphics;
using UnityEngine;

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

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (player.position.x, transform.position.y, -10);
       // DontDestroyOnLoad(gameObject);

       /*if(Scene == "Menu" || Scene == "Winscreen")
       {
            Destroy(gameObject);
       }*/
    }
}
