using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Highscore : MonoBehaviour
{
    public TMP_Text WinText;
    public TMP_Text CabooseText;
    public TMP_Text BoxingText;
    public TMP_Text TargetText;
    public TMP_Text BulletText;
    public TMP_Text GloxText;
    public TMP_Text BasicText;
    public TMP_Text BonusText;
    float highTime = 0;
    float bestMinutes;
    float bestSeconds;
    float cabooseMinutes;
    float cabooseSeconds;
    float cabooseTime;
    string cabooseString;
    float boxingMinutes;
    float boxingSeconds;
    float targetMinutes;
    float targetSeconds;
    float bulletMinutes;
    float bulletSeconds;
    float basicMinutes;
    float basicSeconds;
    float bonusMinutes;
    float bonusSeconds;
    public GameObject gun;
    GameController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("GameController").GetComponent<GameController>();
        if (controller.BestTime1 == 0 || controller.BestTime2 == 0 || controller.BestTime3 == 0 || controller.BestTime4 == 0 || controller.BestTime5 == 0 || controller.BestTime6 == 0)
        {
            WinText.text = "Data insufficient                              Total Time-?:??";
        }
        else if (controller.BestTime1 + controller.BestTime2 + controller.BestTime3 + controller.BestTime4 + controller.BestTime5 + controller.BestTime6 < highTime ||highTime == 0 )
        {
            highTime = controller.BestTime1 + controller.BestTime2 + controller.BestTime3 + controller.BestTime4 + controller.BestTime5 + controller.BestTime6;
            bestMinutes = Mathf.FloorToInt(highTime / 60);
            bestSeconds = highTime % 60;
            if (bestSeconds < 10)
            {
                WinText.text = "You win!(So far)                            Total Time-" + bestMinutes + ":0" + string.Format("{0:#.00}", bestSeconds);
            }
            else
            {
                WinText.text = "You win!(So far)                            Total Time-" + bestMinutes + ":" + string.Format("{0:#.00}", bestSeconds);
            }
        }
        cabooseMinutes = Mathf.FloorToInt(controller.BestTime1 / 60);
        cabooseSeconds = Mathf.FloorToInt(controller.BestTime1 % 60 * 100);

        CabooseText.text = "The Caboose-" + string.Format("{0:#.00}", controller.BestTime1);

        BoxingText.text = "Boxing Buttons-" + string.Format("{0:#.00}", controller.BestTime2);

        TargetText.text = "Target Practice-" + string.Format("{0:#.00}", controller.BestTime3);

        BulletText.text = "Follow that Bullet-" + string.Format("{0:#.00}", controller.BestTime4);

        GloxText.text = "Gloxing Day-" + string.Format("{0:#.00}", controller.BestTime5);

        BasicText.text = "Beta Basics-" + string.Format("{0:#.00}", controller.BestTime6);

        BonusText.text = "Beta Bonus-" + string.Format("{0:#.00}", controller.BestTime7);
        /*
        boxingMinutes = Mathf.FloorToInt(controller.BestTime2 / 60);
        boxingSeconds = Mathf.FloorToInt(controller.BestTime2 % 60);
        if (boxingSeconds < 10)
        {
            BoxingText.text = "Boxing Buttons-" + boxingMinutes + ":0" + boxingSeconds;
        }
        else
        {
            BoxingText.text = "Boxing Buttons-" + boxingMinutes + ":" + boxingSeconds;
        }
        targetMinutes = Mathf.FloorToInt(controller.BestTime3 / 60);
        targetSeconds = Mathf.FloorToInt(controller.BestTime3 % 60);
        if (targetSeconds < 10)
        {
            TargetText.text = "Target Practice-" + targetMinutes + ":0" + targetSeconds;
        }
        else
        {
            TargetText.text = "Target Practice-" + targetMinutes + ":" + targetSeconds;
        }
        bulletMinutes = Mathf.FloorToInt(controller.BestTime4 / 60);
        bulletSeconds = Mathf.FloorToInt(controller.BestTime4 % 60);
        if (bulletSeconds < 10)
        {
            BulletText.text = "Follow that Bullet-" + bulletMinutes + ":0" + bulletSeconds;
        }
        else
        {
            BulletText.text = "Follow that Bullet-" + bulletMinutes + ":" + bulletSeconds;
        }
        basicMinutes = Mathf.FloorToInt(controller.BestTime5 / 60);
        basicSeconds = Mathf.FloorToInt(controller.BestTime5 % 60);
        if (basicSeconds < 10)
        {
            BasicText.text = "Beta Basics-" + basicMinutes + ":0" + basicSeconds;
        }
        else
        {
            BasicText.text = "Beta Basics-" + basicMinutes + ":" + basicSeconds;
        }
        bonusMinutes = Mathf.FloorToInt(controller.BestTime6 / 60);
        bonusSeconds = Mathf.FloorToInt(controller.BestTime6 % 60);
        if (bonusSeconds < 10)
        {
            BonusText.text = "Beta Bonus-" + bonusMinutes + ":0" + bonusSeconds;
        }
        else
        {
            BonusText.text = "Beta Bonus-" + bonusMinutes + ":" + bonusSeconds;
        } */
        print(controller.UsedGUN);
        if (controller.UsedGUN == 1)
        {
            gun.SetActive(true);
            print("Gun");
        } else
        {
            gun.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
