using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    [SerializeField]
    [Header("プレイヤー1")]
    PlayerBase _player1;

    [SerializeField]
    [Header("プレイヤー2")]
    PlayerBase _player2;

    [SerializeField]
    [Header("最初のテキスト")]
    Text _text;

    const int ONE = 1000;
    const string READY = "Ready...";
    const string GO = "Go!";

    async void Awake()
    {
        _text.gameObject.SetActive(true);
        _player1.enabled = false;
        _player2.enabled = false;
        _text.text = READY;
        await Task.Delay(ONE);
        _text.text = GO;
        _player1.enabled = true;
        _player2.enabled = true;
        await Task.Delay(ONE);
        _text.gameObject.SetActive(false);
    }
}
