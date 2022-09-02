using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Threading.Tasks;

public class BattleView : MonoBehaviour
{
    [SerializeField]
    [Header("プレイヤー1の所持ポイントのテキスト")]
    Text _p1PointText;

    [SerializeField]
    [Header("プレイヤー2の所持ポイントのテキスト")]
    Text _p2PointText;

    [SerializeField]
    [Header("2人のポイントのテキスト")]
    Text _vsText;

    const int ONE_SECOND = 1000;

    void Awake()
    {
        _p1PointText.text = "0";
        _p2PointText.text = "0";
    }

    public async void PointText(int point,PlayerType type)
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

        if(point != 0)
        {
            _vsText.text = _p1PointText.text + " VS " + _p2PointText.text;
            _vsText.gameObject.SetActive(true);
            await Task.Delay(ONE_SECOND);
            _vsText.gameObject.SetActive(false);
        }    
    }
}
