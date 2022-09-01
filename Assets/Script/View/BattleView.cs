using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class BattleView : MonoBehaviour
{
    [SerializeField]
    [Header("プレイヤー1の所持ポイントのテキスト")]
    Text _p1PointText;

    [SerializeField]
    [Header("プレイヤー2の所持ポイントのテキスト")]
    Text _p2PointText;


    void Awake()
    {
        
    }

    void Update()
    {
        
    }

    public void PointText(int point,PlayerType type)
    {
        switch (type)
        {
            case PlayerType.Player1:
                _p1PointText.text = point.ToString();
                break;
            case PlayerType.Player2:
                _p2PointText.text = point.ToString();
                break;
        }
    }
}
