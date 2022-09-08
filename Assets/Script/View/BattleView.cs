using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Threading.Tasks;

public class BattleView : MonoBehaviour
{
    [SerializeField]
    [Header("�v���C���[1�̏����|�C���g�̃e�L�X�g")]
    Text _p1PointText;

    [SerializeField]
    [Header("�v���C���[2�̏����|�C���g�̃e�L�X�g")]
    Text _p2PointText;

    [SerializeField]
    [Header("2�l�̃|�C���g�̃e�L�X�g")]
    Text _vsText;

    [SerializeField]
    [Header("���҂̃e�L�X�g")]
    Text _winnerText;

    [SerializeField]
    [Header("�|�[�Y�̃p�l��")]
    Image _pausePanel;

    const int ONE_SECOND = 1000;
    const string PLAYER1 = "�v���C���[1";
    const string PLAYER2 = "�v���C���[2";
    const string WINEER = "�̏���";

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

    public async void PlayerWinner(PlayerType type)
    {
        switch (type)
        {
            case PlayerType.Empty:
                return;
            case PlayerType.Player1:
                _winnerText.text = PLAYER1 + WINEER;
                break;
            case PlayerType.Player2:
                _winnerText.text = PLAYER2 + WINEER;
                break;
        }

        await Task.Delay(ONE_SECOND);
        _winnerText.gameObject.SetActive(true);
        await Task.Delay(ONE_SECOND);
        _winnerText.gameObject.SetActive(false);
        _pausePanel.gameObject.SetActive(true);
    }
}
