using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class LoadScenePresenter : MonoBehaviour
{
    [SerializeField]
    [Header("ロードシーンモデル")]
    LoadSceneModel _loadSceneModel;

    [SerializeField]
    [Header("リプレイボタン")]
    Button _replayButton;

    [SerializeField]
    [Header("セレクトボタン")]
    Button _selectButton;

    [SerializeField]
    [Header("タイトルへ戻るボタン")]
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
