using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Eeveeon").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (player.position.x, transform.position.y, -10);
    }
}
