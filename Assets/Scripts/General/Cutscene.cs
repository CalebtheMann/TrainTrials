using System.Collections;
using System.Collections.Generic;
using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    public GameObject House;
    public GameObject Fireplace;
    public GameObject ReadEeveeon;
    public GameObject Chair;
    public GameObject RedEeveeon;
    public GameObject Newspaper;
    public GameObject Gun;
    public AudioClip Stinger;
    public AudioClip Knock;
    public AudioClip Bang;
    public AudioClip IRS;
    public AudioClip Boom;
    public AudioClip Stinger2;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(Stinger, Camera.main.transform.position, 0.3f);
        Invoke("Scene1", 3);
        Invoke("Scene2", 6);
        Invoke("Scene3", 10);
        Invoke("Scene4", 13);
        Invoke("End", 23);
    }

    void Scene1()
    {
        House.SetActive(false);
        Fireplace.SetActive(true);
        Chair.SetActive(true);
        ReadEeveeon.SetActive(true);

    }
    void Scene2()
    {
        Chair.SetActive(false);
        ReadEeveeon.SetActive(false);
        Newspaper.SetActive(true);
        AudioSource.PlayClipAtPoint(Knock, Camera.main.transform.position, 0.5f);
        Invoke("DoorBang", 2.5f);
        Invoke("ThisIsThe", 5);
    }
    void DoorBang()
    {
        AudioSource.PlayClipAtPoint(Bang, Camera.main.transform.position, 0.5f);
    }
    void ThisIsThe()
    {
        AudioSource.PlayClipAtPoint(IRS, Camera.main.transform.position, 0.5f);
    }
    void Scene3()
    {
        Chair.SetActive(true);
        RedEeveeon.SetActive(true);
    }
    void Scene4()
    {
        Chair.SetActive(false);
        RedEeveeon.SetActive(false);
        Invoke("GunSpawn", 2.31f);
        Invoke("DoorHit", 4.7f);
        Invoke("ThatsAll", 7.5f);
    }
    void GunSpawn()
    {
        Gun.SetActive(true);
    }
    void DoorHit()
    {
        AudioSource.PlayClipAtPoint(Boom, Camera.main.transform.position, 0.5f);
    }
    void ThatsAll()
    {
        AudioSource.PlayClipAtPoint(Stinger2, Camera.main.transform.position, 0.3f);
    }
    void End()
    {
        SceneManager.LoadScene("BetaCars");
    }
}
