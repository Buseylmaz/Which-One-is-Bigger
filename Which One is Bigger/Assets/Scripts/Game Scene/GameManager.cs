using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Alpha Game Object ")]
    [SerializeField] GameObject scorePanel;
    [SerializeField] GameObject compareText;
    [SerializeField] float alphaTime = 1;
    int alphaValue = 1;

    [Header("Game Object Array")]
    [SerializeField] GameObject[] rectangleImage;
    [SerializeField] float transformTime = 1f;
    int startTransform = 0;
    


    void Start()
    {
        UpdateAlpha();
        UpdateGameObjectTransform();
    }

    
  
    void UpdateAlpha()
    {
        scorePanel.GetComponent<CanvasGroup>().DOFade(alphaValue, alphaTime);
        compareText.GetComponent<CanvasGroup>().DOFade(alphaValue, alphaTime);

    }

    void UpdateGameObjectTransform()
    {
        foreach (var rectangle in rectangleImage)
        {
            rectangle.GetComponent<RectTransform>().DOLocalMoveX(startTransform, transformTime).SetEase(Ease.OutBack);
        }
    }
}
