using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class BattleLoadSceneButtonSetting : MonoBehaviour
{
    [SerializeField]
    [Header("���[�h�V�[�����f��")]
    SceneLoader _loadSceneModel;

    [SerializeField]
    [Header("���v���C�{�^��")]
    Button _replayButton;

    [SerializeField]
    [Header("�Z���N�g�{�^��")]
    Button _selectButton;

    [SerializeField]
    [Header("�^�C�g���֖߂�{�^��")]
    Button _backToTitleButton;

    void Awake()
    {
        _replayButton
            .onClick
            .AddListener(() => 
                _loadSceneModel
                    .LoadScene(SceneType.BattleScene));

        _selectButton
            .onClick
            .AddListener(() =>
                _loadSceneModel
                .LoadScene(SceneType.HomeScene));

        _backToTitleButton
            .onClick
            .AddListener(() =>
                _loadSceneModel
                    .LoadScene(SceneType.TitleScene));
    }
}
