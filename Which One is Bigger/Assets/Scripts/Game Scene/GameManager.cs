using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Alpha Game Object Array ")]
    [SerializeField] GameObject[] alphaImage;
    [SerializeField] float alphaTime = 1.5f;
    int alphaValue = 1;

    [Header("Game Object Array")]
    [SerializeField] GameObject[] rectangleImage;
    [SerializeField] Text downText, upText;
    [SerializeField] float transformTime = 1f;
    int startTransform = 0;

    ScoreTimeManager scoreTimeManager;

    private void Awake()
    {
        scoreTimeManager = Object.FindObjectOfType<ScoreTimeManager>();
    }

    void Start()
    {
        upText.text = "";
        downText.text = "";

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

        scoreTimeManager.StartTime();

       //text alpha deðerini 0 lamak lazým 
    }
}
