using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTimeManager : MonoBehaviour
{
    [SerializeField] Text timeText;

    int remainingTime;

    bool isTime;


    void Start()
    {
        remainingTime = 90;

        isTime = true;
    }


    public void StartTime()
    {
        StartCoroutine(TimerRoutine());
    }

    IEnumerator TimerRoutine()
    {
        while (isTime)
        {
            yield return new WaitForSeconds(1f);

            if (remainingTime < 10)
            {
                timeText.text = ": 0" + remainingTime.ToString();
            }
            else
            {
                timeText.text = ": " + remainingTime.ToString();
            }

            if (remainingTime <= 0)
            {
                isTime = false;
                timeText.text = ": 00";
            }

            remainingTime--;
        }
    }

}
