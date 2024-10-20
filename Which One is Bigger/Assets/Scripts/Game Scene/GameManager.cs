using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Alpha Game Object Array ")]
    [SerializeField] GameObject[] alphaImage;
    [SerializeField] GameObject bigNumberText;
    [SerializeField] float alphaTime = 1.5f;
    int alphaValue = 1;
    int alphaValue_ = 0;

    [Header("Game Object Array")]
    [SerializeField] GameObject[] rectangleImage;
    [SerializeField] Text downText, upText;
    [SerializeField] float transformTime = 1f;
    int startTransform = 0;

    ScoreTimeManager scoreTimeManager;
    RoundManager roundManager;

    int gameCounter, isLevel;
    int upValue, downValue;

    int biggerValue;

    int startValue = 0;
    int finishValue=50;
    int value1 = 1;
    int value2 = 2;

    int buttonValue;

    private void Awake()
    {
        scoreTimeManager = Object.FindObjectOfType<ScoreTimeManager>();
        roundManager = Object.FindObjectOfType<RoundManager>();
    }

    void Start()
    {
        gameCounter = 0;
        isLevel = 0;

        UpdateAlpha();
        UpdateGameObjectTransform();
    }

    
  
    void UpdateAlpha()
    {
        foreach (var alpha in alphaImage)
        {
            alpha.GetComponent<CanvasGroup>().DOFade(alphaValue, alphaTime);
        }
    }

    void UpdateGameObjectTransform()
    {
        foreach (var rectangle in rectangleImage)
        {
            rectangle.GetComponent<RectTransform>().DOLocalMoveX(startTransform, transformTime).SetEase(Ease.OutBack);
        }
    }

    public void StartGame()
    {
        alphaImage[1].GetComponent<CanvasGroup>().DOFade(alphaValue_, alphaTime);//Compare text 
        bigNumberText.GetComponent<CanvasGroup>().DOFade(alphaValue, alphaTime);//Big Number text 

        scoreTimeManager.StartTime();

        WhichLevel();
    }

    void WhichLevel()
    {
        if (gameCounter<5)
        {
            isLevel = 1;
        }

        switch (isLevel)
        {
            case 1:
                Level1();
                break;
        }
    }

    void Level1()
    {
        int randomValue = Random.Range(startValue, finishValue);

        if (randomValue<=25)
        {
            upValue = Random.Range(value2, finishValue);
            downValue = upValue + Random.Range(value1, finishValue);
        }
        else
        {
            upValue = Random.Range(value2, finishValue);
            downValue = Mathf.Abs(upValue - Random.Range(value1, finishValue));
        }

        if (upValue > downValue)
        {
            biggerValue = upValue;
        }
        else
        {
            biggerValue = downValue;
        }

        upText.text = upValue.ToString();
        downText.text = downValue.ToString();


        Debug.Log("Bigger: " + biggerValue);
    }

    public void ButtonValue(string buttonName)
    {
        if (buttonName=="UpButton")
        {
            buttonValue = upValue;
        }
        else if (buttonName == "DownButton")
        {
            buttonValue = downValue;
        }
        //Debug.Log(buttonValue);

        if (buttonValue==biggerValue)
        {
            //Debug.Log("True");
            roundManager.OpenRoundScale(gameCounter % 5);
            gameCounter++;
        }
        else
        {
            Debug.Log("False");
        }
    }

}
