using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RoundManager : MonoBehaviour
{
    [SerializeField] GameObject[] roundArray;

    void Start()
    {
        CloseRoundScale();
    }

    void CloseRoundScale()
    {
        foreach (var round in roundArray)
        {
            round.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
    }
   
   public void OpenRoundScale(int isRound)
   {
        roundArray[isRound].GetComponent<RectTransform>().DOScale(1, 0.3f);
   }
}
