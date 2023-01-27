using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDoor : MonoBehaviour
{
    public GameObject Target;
    public GameObject Target2;
    public GameObject Target3;
    bool rise = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Target && !Target2 && !Target3)
        {
            rise = true;
            Invoke("RiseEnd", 3);
        }
        if (rise)
        {
            Vector2 newPosition = transform.position;
            newPosition.y += 3 * Time.deltaTime;
            transform.position = new Vector2(newPosition.x, newPosition.y);
        }
    }
    void RiseEnd()
    {
        Destroy(this);
    }
}
