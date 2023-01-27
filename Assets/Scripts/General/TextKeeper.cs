using UnityEngine;
using TMPro;
using System;

public class TextKeeper : MonoBehaviour
{
    float minutes;
    float seconds;
    public TMP_Text TimerBox;
    public TMP_Text LevelBox;
    public TMP_Text Death;
    public TMP_Text Death2;
    public TMP_Text GunTutorial;
    GameController controller;
    PlayerBehavior player;
    // Start is called before the first frame update
    void Start()
    {
        Death.gameObject.SetActive(false);
        Death2.gameObject.SetActive(false);
        Invoke("LevelUpdate", .01f);
        controller = GameObject.Find("GameController").GetComponent<GameController>();
        player = GameObject.Find("Eeveeon").GetComponent<PlayerBehavior>();

    }

    // Update is called once per frame
    void Update()
    {
        controller.TimerTime += Time.deltaTime;
        minutes = Mathf.FloorToInt(controller.TimerTime / 60);
        seconds = Mathf.FloorToInt(controller.TimerTime % 60);
        if (seconds < 10)
            {
                TimerBox.text = minutes + ":0" + seconds;
            }
        else
            {
             TimerBox.text = minutes + ":" + seconds;
            }
        if (player.Gun)
            {
            GunTutorial.gameObject.SetActive(true);
            } 
        else
            {
            GunTutorial.gameObject.SetActive(false);
            }
    }

    public void TimerReset()
    {
        controller.TimerTime = 0;
    }

    public void LevelUpdate()
    {
        if (TimerBox.gameObject != null)
        {
            switch (controller.CurrentCar)
            {
                case 0:
                    LevelBox.text = "The Caboose";
                    break;
                case 1:
                    LevelBox.text = "Blocking Buttons";
                    break;
                case 2:
                    LevelBox.text = "Target Practice";
                    break;
                case 3:
                    LevelBox.text = "Follow that Bullet!";
                    break;
                case 4:
                    LevelBox.text = "Gloxing Day";
                    break;
                case 5:
                    LevelBox.text = "The Beta Basics";
                    break;
                case 6:
                    LevelBox.text = "The Beta Bonus";
                    break;
                default:
                    LevelBox.text = "Mysterious Traincar";
                    break;
            }
        }
    }
    public void BestTime()
    {
        switch (controller.CurrentCar - 1)
        {
            case 0:
                if (controller.TimerTime < controller.BestTime1 || controller.BestTime1 == 0)
                {
                    controller.BestTime1 = controller.TimerTime;
                    PlayerPrefs.SetFloat("1", controller.TimerTime);
                }
                print(controller.BestTime1);
                break;
            case 1:
                if (controller.TimerTime < controller.BestTime2 || controller.BestTime2 == 0)
                {
                    controller.BestTime2 = controller.TimerTime;
                    PlayerPrefs.SetFloat("2", controller.TimerTime);
                }
                print(controller.BestTime2);
                break;
            case 2:
                if (controller.TimerTime < controller.BestTime3 || controller.BestTime3 == 0)
                {
                    controller.BestTime3 = controller.TimerTime;
                    PlayerPrefs.SetFloat("3", controller.TimerTime);
                }
                print(controller.BestTime3);
                break;
            case 3:
                if (controller.TimerTime < controller.BestTime4 || controller.BestTime4 == 0)
                {
                    controller.BestTime4 = controller.TimerTime;
                    PlayerPrefs.SetFloat("4", controller.TimerTime);
                }
                print(controller.BestTime4);
                break;
            case 4:
                if (controller.TimerTime < controller.BestTime5 || controller.BestTime5 == 0)
                {
                    controller.BestTime5 = controller.TimerTime;
                    PlayerPrefs.SetFloat("5", controller.TimerTime);
                }
                print(controller.BestTime5);
                break;
            case 5:
                if (controller.TimerTime < controller.BestTime6 || controller.BestTime6 == 0)
                {
                    controller.BestTime6 = controller.TimerTime;
                    PlayerPrefs.SetFloat("6", controller.TimerTime);
                }
                print(controller.BestTime6);
                break;
            case 6:
                if (controller.TimerTime < controller.BestTime7 || controller.BestTime7 == 0)
                {
                    controller.BestTime7 = controller.TimerTime;
                    PlayerPrefs.SetFloat("7", controller.TimerTime);
                }
                print(controller.BestTime7);
                break;
            default:
                break;

        }
    }
    public void DeathScreen()
    {
        Death.gameObject.SetActive(true);
        Death2.gameObject.SetActive(true);
    }
    public void DeathScreenDeath()
    {
        Death.gameObject.SetActive(false);
        Death2.gameObject.SetActive(false);
    }
}
