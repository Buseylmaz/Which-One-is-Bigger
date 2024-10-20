using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Transform brainImage;
    [SerializeField] Transform startButton;

    
    void Start()
    {
        brainImage.transform.GetComponent<RectTransform>().DOLocalMoveX(0f, 1f).SetEase(Ease.OutBack);
        startButton.transform.GetComponent<RectTransform>().DOLocalMoveY(380f, 1f).SetEase(Ease.OutBack);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
