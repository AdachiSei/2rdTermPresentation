using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class BattleLoadSceneButtonSetting : MonoBehaviour
{
    [SerializeField]
    [Header("ロードシーンモデル")]
    SceneLoader _loadSceneModel;

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
