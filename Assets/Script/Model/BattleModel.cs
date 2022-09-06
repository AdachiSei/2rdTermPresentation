using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class BattleModel : MonoBehaviour
{
    public IReadOnlyReactiveProperty<int> Player1Point => _player1Point;
    public IReadOnlyReactiveProperty<int> Player2Point => _player2Point;
    public IReadOnlyReactiveProperty<PlayerType> Judg => _judg;

    public bool IsGame => _isGame;

    [SerializeField]
    [Header("âΩÉ|ÉCÉìÉgêÊéÊÇ©")]
    int _winPoint = 5;

    bool _isGame;

    readonly IntReactiveProperty _player1Point = new();
    readonly IntReactiveProperty _player2Point = new();
    readonly ReactiveProperty<PlayerType> _judg = new();


    public void PlusPoint(PlayerType type)
    { 
        switch (type)
        {
            case PlayerType.Player1:
                _player1Point.Value++;
                break;
            case PlayerType.Player2:
                _player2Point.Value++;
                break;
        }

        if( _player1Point.Value >= _winPoint)
        {
            _isGame = true;
            _judg.Value = PlayerType.Player1;
        }
        else if(_player2Point.Value >= _winPoint)
        {
            _isGame = true;
            _judg.Value = PlayerType.Player2;
        }
    }

    void OnDestroy()
    {
        _player1Point.Dispose();
        _player2Point.Dispose();
    }
}
