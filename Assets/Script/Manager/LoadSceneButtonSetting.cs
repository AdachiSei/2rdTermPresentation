using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSceneButtonSetting : MonoBehaviour
{
    [SerializeField]
    [Header("�V�[�����[�_�[")]
    SceneLoader _sceneLoader;

    [SerializeField]
    [Header("�V�[����ǂݍ��ރ{�^��")]
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
        [Tooltip("���O")]
        string _name;

        [SerializeField]
        [Tooltip("�ǂ��ɍs��������")]
        SceneType _type;

        [SerializeField]
        [Tooltip("�{�^��")]
        Button _button;
    }
}
