using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : SingletonMonoBehaviour<PauseManager>
{
    public event Action OnPause;
    public event Action OnResume;

    [SerializeField]
    [Header("ƒpƒbƒN")]
    PackController _packController;

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
                _isPause = true;
                break;
            case true:
                OnResume.Invoke();
                _isPause = false;
                break;
        }
    }
}
