using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPointButtonSetting : MonoBehaviour
{
    [SerializeField]
    [Header("3�{�^��")]
    Button _threeButton;

    [SerializeField]
    [Header("5�{�^��")]
    Button _fiveButton;

    [SerializeField]
    [Header("10�{�^��")]
    Button _tenButton;

    private void Awake()
    {
        _threeButton.onClick.AddListener(() => ChangeWinPoint(3));
        _fiveButton.onClick.AddListener(() => ChangeWinPoint(5));
        _tenButton.onClick.AddListener(() => ChangeWinPoint(10));
    }

    void ChangeWinPoint(int point)
    {
        PointManager.Instance.ChangeWinPoint(point);
    }
}
