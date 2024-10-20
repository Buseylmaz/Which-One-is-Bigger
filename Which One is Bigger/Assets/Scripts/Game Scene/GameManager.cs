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
        if (gameCounter < 5)
        {
            isLevel = 1;
        }
        else if (gameCounter >= 5 && gameCounter < 10)
        {
            isLevel = 2;
        }
        else if (gameCounter >= 10 && gameCounter < 15)
        {
            isLevel = 3;
        }
        else if (gameCounter >= 15 && gameCounter < 20)
        {
            isLevel = 4;
        }
        else if (gameCounter >= 20 && gameCounter < 25)
        {
            isLevel = 5;
        }
        else
        {
            isLevel = Random.Range(1, 6);
        }


        switch (isLevel)
        {
            case 1:
                Level1();
                break;
            case 2:
                Level2();
                break;
            case 3:
                Level3();
                break;
            case 4:
                Level4();
                break;
            case 5:
                Level5();
                break;

        }
    }

    void Level1()
    {
        int randomValue = Random.Range(value1, finishValue);

        if (randomValue <= 25)
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


        //Debug.Log("Bigger: " + biggerValue);
    }

    void Level2()
    {
        int firstNumber = Random.Range(1, 10);
        int secondNumber = Random.Range(1, 20);
        int thirdNumber = Random.Range(1, 10);
        int fourthNumber = Random.Range(1, 20);


        upValue = firstNumber + secondNumber;
        downValue = thirdNumber + fourthNumber;

        if (upValue > downValue)
        {
            biggerValue = upValue;
        }
        else if(upValue < downValue)
        {
            biggerValue = downValue;
        }

        if (upValue == downValue)
        {
            Level2();
            return;
        }

        upText.text = firstNumber + " + " + secondNumber;
        downText.text = thirdNumber + " + " + fourthNumber;

    }

    void Level3()
    {
        int firstNumber = Random.Range(11, 20);
        int secondNumber = Random.Range(1, 11);
        int thirdNumber = Random.Range(1, 20);

        int fourthNumber = Random.Range(11, 20);
        int fifthNumber = Random.Range(1, 11);
        int sixthNumber = Random.Range(1, 20);



        upValue = firstNumber - secondNumber + thirdNumber;
        downValue = fourthNumber - fifthNumber + sixthNumber;

        if (upValue > downValue)
        {
            biggerValue = upValue;
        }
        else if (upValue < downValue)
        {
            biggerValue = downValue;
        }

        if (upValue == downValue)
        {
            Level3();
            return;
        }

        upText.text = firstNumber + " - " + secondNumber + " + " + thirdNumber;
        downText.text = fourthNumber + " - " + fifthNumber + " + " + sixthNumber;
    }

    void Level4()
    {
        int firstNumber = Random.Range(1, 15);
        int secondNumber = Random.Range(1, 10);
        int thirdNumber = Random.Range(1, 15);
        int fourthNumber = Random.Range(1, 10);


        upValue = firstNumber * secondNumber;
        downValue = thirdNumber * fourthNumber;

        if (upValue > downValue)
        {
            biggerValue = upValue;
        }
        else if (upValue < downValue)
        {
            biggerValue = downValue;
        }

        if (upValue == downValue)
        {
            Level4();
            return;
        }

        upText.text = firstNumber + " x " + secondNumber;
        downText.text = thirdNumber + " x " + fourthNumber;
    }

    void Level5()
    {
        int firstNumber = Random.Range(15, 50);
        int secondNumber = Random.Range(1, 15);
        int thirdNumber = Random.Range(1, 10);

        int fourthNumber = Random.Range(1, 15);
        int fifthNumber = Random.Range(15, 50);
        int sixthNumber = Random.Range(1, 10);


        upValue = firstNumber - secondNumber + (thirdNumber * secondNumber);
        downValue = fifthNumber - fourthNumber + (fourthNumber * sixthNumber);

        if (upValue > downValue)
        {
            biggerValue = upValue;
        }
        else if (upValue < downValue)
        {
            biggerValue = downValue;
        }

        if (upValue == downValue)
        {
            Level5();
            return;
        }

        upText.text = firstNumber +  " - " + secondNumber + " + " + " (" + thirdNumber + " x " + secondNumber+ ") ";
        downText.text = fifthNumber + " - " + fourthNumber + " + " + " (" + fourthNumber + " x " + sixthNumber + ") ";
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

            WhichLevel();
        }
        else
        {
            //Debug.Log("False");
        }
    }

}
