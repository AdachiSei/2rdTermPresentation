using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class NextBoothView : MonoBehaviour
{
    [SerializeField]
    [Header("UIManager")]
    ChangeUIManager _changeUIManager;

    [SerializeField]
    [Header("���̃u�[�X�ɍs�����߂�Button")]
    List<NextBooth> _nextBooth = new();

    [SerializeField]
    [Header("�߂�{�^��")]
    Button _backBooth;

    void Awake()
    {
        foreach (var button in _nextBooth)
        {
            button
                .NextBoothButton
                .onClick
                .AddListener(() => _changeUIManager
                .NextMenu(/*button.BoothType*/));
        }

        _backBooth.onClick.AddListener(_changeUIManager.BackMenu);
    }

    [System.Serializable]
    public class NextBooth
    {
        public Button NextBoothButton => _nextBoothButton;

        public BoothType BoothType => _boothType;

        [SerializeField]
        [Tooltip("�{�^���̖��O")]
        string _buttonName;

        [SerializeField]
        [Tooltip("���ɍs�������u�[�X")]
        BoothType _boothType;

        [SerializeField]
        [Tooltip("���̃u�[�X�ɍs�����߂̃{�^��")]
        Button _nextBoothButton;

    }
}
