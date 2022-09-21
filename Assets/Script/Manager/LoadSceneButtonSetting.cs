using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSceneButtonSetting : MonoBehaviour
{
    [SerializeField]
    [Header("シーンローダー")]
    SceneLoader _sceneLoader;

    [SerializeField]
    [Header("シーンを読み込むボタン")]
    List<LoadSceneButton> _buttons = new();

    void Awake()
    {
        foreach(var i in _buttons)
        {
            i.Button.onClick.AddListener(() => _sceneLoader.LoadScene(i.Type));
        }
    }

    [Serializable]
    public class LoadSceneButton
    {
        public SceneType Type => _type;
        public Button Button => _button;

        [SerializeField]
        [Tooltip("名前")]
        string _name;

        [SerializeField]
        [Tooltip("どこに行きたいか")]
        SceneType _type;

        [SerializeField]
        [Tooltip("ボタン")]
        Button _button;
    }
}
