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
    [Header("次のブースに行くためのButton")]
    List<NextBooth> _nextBooth = new();

    [SerializeField]
    [Header("戻るボタン")]
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
        [Tooltip("ボタンの名前")]
        string _buttonName;

        [SerializeField]
        [Tooltip("次に行きたいブース")]
        BoothType _boothType;

        [SerializeField]
        [Tooltip("次のブースに行くためのボタン")]
        Button _nextBoothButton;

    }
}
