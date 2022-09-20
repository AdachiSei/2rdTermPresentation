using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class HomeLoadScenePresenter : MonoBehaviour
{
    [SerializeField]
    [Header("���[�h�V�[�����f��")]
    SceneLoader _loadSceneModel;

    [SerializeField]
    [Header("�V�[�������[�h���邽�߂̃{�^��")]
    Button _loadSceneButton;

    void Awake()
    {
        _loadSceneButton.OnClickAsObservable().Subscribe(x =>
        {
            _loadSceneModel.LoadScene(SceneType.BattleScene);
        }).AddTo(this);
    }
}
