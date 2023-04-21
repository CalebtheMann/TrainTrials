using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 
public class DestroyBackground : MonoBehaviour
{
    public GameObject Background;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Resetter")
        {
           var item =  CameraController.Instance.Backgrounds.FirstOrDefault(x => x.gameObject == Background);
           if(item != null)
           {
                CameraController.Instance.Backgrounds.Remove(item);
           }
            Destroy(Background);
        }
    }
}
