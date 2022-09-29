using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : SingletonMonoBehaviour<PointManager>
{
    BattleModel _battleModel;

    static int _winPoint = 5;

    private void Update()
    {
        if(!_battleModel)
        {
            _battleModel = FindObjectOfType<BattleModel>();
        }
        _battleModel?.ChangeWinPoint(_winPoint);
    }

    public int ChangeWinPoint(int point) =>
        _winPoint = point;
}
