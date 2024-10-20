using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CountdownTimerManager : MonoBehaviour
{
    [SerializeField] GameObject countdownTimerObje;
    [SerializeField] Text countdownTimerText;

    int startValue = 3;
    int finishValue = 0;

    int imageScale = 1;
    float time_1 = 0.5f;
    float time_2 = 1f;
    float time_3 = 0f;

    GameManager gameManager;


    void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    void Start()
    {
        StartCoroutine(CountdownTimerRoutine());
    }

    IEnumerator CountdownTimerRoutine()
    {
        countdownTimerObje.GetComponent<RectTransform>().DOScale(imageScale, time_1).SetEase(Ease.OutBack);
       
        for (int i = startValue; i > finishValue; i--)
        {
            countdownTimerText.text = i.ToString();
            yield return new WaitForSeconds(time_2);
        }
        

        countdownTimerObje.GetComponent<RectTransform>().DOScale(finishValue, time_3).SetEase(Ease.InBack);

        StopAllCoroutines();


        gameManager.StartGame();

    }
}
