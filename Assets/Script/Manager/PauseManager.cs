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
    float _timer;

    const float ONE_SECONDS = 1;
    const string CANCEL = "Cancel";

    void Update()
    {
        _timer += Time.deltaTime;
        bool isCancel = Input.GetButtonDown(CANCEL);
        bool isPack = _packController.gameObject.activeSelf;
        bool oneSecondLater = _timer >= ONE_SECONDS;
        if (isCancel && isPack && oneSecondLater)
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
