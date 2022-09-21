using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public event Action OnPause;
    public event Action OnResume;

    [SerializeField]
    [Header("パック")]
    PackController _packController;

    [SerializeField]
    [Header("ポーズパネル")]
    Image _pausePanel;

    bool _isPause;

    const string CANCEL = "Cancel";

    void Update()
    {
        if (Input.GetButtonDown(CANCEL) && _packController.gameObject.activeSelf)
        {
            Pause();
        }
    }

    void Pause()
    {
        switch (_isPause)
        {
            case false:
                OnPause.Invoke();
                _pausePanel.gameObject.SetActive(true);
                _isPause = true;
                break;
            case true:
                OnResume.Invoke();
                _pausePanel.gameObject.SetActive(false);
                _isPause = false;
                break;
        }
    }
}
