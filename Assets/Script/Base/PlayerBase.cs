using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player�𐧌䂷����N���X
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerBase : MonoBehaviour
{
    [SerializeField]
    [Header("�v���C���[�̃^�C�v")]
    PlayerType _playerType;

    [SerializeField]
    [Header("�X�s�[�h")]
    float _speed = 20;

    [SerializeField]
    [Header("�������̃X�s�[�h")]
    float _slowSpeed = 3;

    Rigidbody _rb;
    string _hName;
    string _vName;
    string _slowName;
    bool _isPlay = true;
    KeyCode _slowKey;
    
    const string HORIZONTAL = "Horizontal";
    const string VERTICAL = "Vertical";
    const string HORIZONTAL2 = "Horizontal2";
    const string VERTICAL2 = "Vertical2";
    const string SLOW = "Slow";
    const string SLOW2 = "Slow2";

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        PauseManager.Instance.OnPause += OnPause;
        PauseManager.Instance.OnResume += OnResume;

        switch(_playerType)
        {
            case PlayerType.Player1:
                _hName = HORIZONTAL;
                _vName = VERTICAL;
                //_slowKey = KeyCode.LeftShift;
                _slowName = SLOW;
                break;
            case PlayerType.Player2:
                _hName = HORIZONTAL2;
                _vName = VERTICAL2;
                //_slowKey = KeyCode.Keypad0;
                _slowName = SLOW2;
                break;
            default:
                Debug.Log("�v���C���[�̃^�C�v��ݒ肵�Ă�������");
                break;
        }
    }

    protected virtual void Update()
    {
        if(_isPlay)
        {
            //Cursor.lockState = CursorLockMode.Locked;
            Move();
        }
    }

    protected virtual void Move()
    {
        float h = Input.GetAxisRaw(_hName);
        float v = Input.GetAxisRaw(_vName);

        if(Input.GetButton(_slowName))
        {
            _rb.velocity = new Vector3(h, 0f, v).normalized * _slowSpeed;
        }
        else
        {
            _rb.velocity = new Vector3(h, 0f, v).normalized * _speed;
        }
    }

    void OnPause()
    {
        _isPlay = false;
        _rb.constraints = RigidbodyConstraints.FreezePosition;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void OnResume()
    {
        _isPlay = true;
        _rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }
}
