using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class BattleModel : MonoBehaviour
{
    public IReadOnlyReactiveProperty<int> Player1Point => _player1Point;
    public IReadOnlyReactiveProperty<int> Player2Point => _player2Point;
    public bool IsGame => _isGame;

    [SerializeField]
    [Header("‰½ƒ|ƒCƒ“ƒgæŽæ‚©")]
    int _winPoint = 5;

    bool _isGame;
    bool _isWinPlayer1;

    readonly IntReactiveProperty _player1Point = new();
    readonly IntReactiveProperty _player2Point = new();


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
            _isWinPlayer1 = true;
        }
        else if(_player2Point.Value >= _winPoint)
        {
            _isGame = true;
            _isWinPlayer1 = false;
        }
    }

    void OnDestroy()
    {
        _player1Point.Dispose();
        _player2Point.Dispose();
    }
}
