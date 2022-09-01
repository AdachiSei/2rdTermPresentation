using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class BattleView : MonoBehaviour
{
    [SerializeField]
    [Header("�v���C���[1�̏����|�C���g�̃e�L�X�g")]
    Text _p1PointText;

    [SerializeField]
    [Header("�v���C���[2�̏����|�C���g�̃e�L�X�g")]
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
