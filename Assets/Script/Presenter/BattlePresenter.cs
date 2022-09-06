using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class BattlePresenter : MonoBehaviour
{
    [SerializeField]
    BattleModel _battleModel;

    [SerializeField]
    BattleView _battleView;

    void Awake()
    {
        _battleModel.Player1Point.Subscribe(point =>
        {
            _battleView.PointText(point,PlayerType.Player1);
        }).AddTo(this);

        _battleModel.Player2Point.Subscribe(point =>
        {
            _battleView.PointText(point, PlayerType.Player2);
        }).AddTo(this);

        _battleModel.Judg.Subscribe(playerType =>
        {
            _battleView.PlayerWinner(playerType);
        }).AddTo(this);
    }
}
