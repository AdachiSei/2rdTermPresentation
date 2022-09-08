using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class LoadScenePresenter : MonoBehaviour
{
    [SerializeField]
    [Header("���[�h�V�[�����f��")]
    LoadSceneModel _loadSceneModel;

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
        _replayButton.OnClickAsObservable().Subscribe(x =>
        {
            _loadSceneModel.LoadScene(SceneType.BattleScene);
        }).AddTo(this);

        _selectButton.OnClickAsObservable().Subscribe(x =>
        {
            _loadSceneModel.LoadScene(SceneType.SelectScene);
        }).AddTo(this);

        _backToTitleButton.OnClickAsObservable().Subscribe(x =>
        {
            _loadSceneModel.LoadScene(SceneType.TitleScene);
        }).AddTo(this);
    }
}
