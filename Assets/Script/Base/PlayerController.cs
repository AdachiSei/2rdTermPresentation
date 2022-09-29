using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player�𐧌䂷��N���X
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    [Header("�|�[�Y�}�l�[�W���[")]
    PauseManager _pauseManager;

    [SerializeField]
    [Header("�v���C���[�̃^�C�v")]
    PlayerType _playerType;

    [SerializeField]
    [Header("�p�b�N")]
    PackController _packController;

    [SerializeField]
    [Header("�X�s�[�h")]
    float _speed = 20;

    [SerializeField]
    [Header("�������̃X�s�[�h")]
    float _slowSpeed = 3;

    [SerializeField]
    [Header("�v���C���[1�̒�ʒu")]
    Vector3 _player1Pos = new Vector3(-7f,0.15f,-3);

    [SerializeField]
    [Header("�v���C���[2�̒�ʒu")]
    Vector3 _player2Pos = new Vector3(7f, 0.15f, 3);

    Rigidbody _rb;
    string _hName;
    string _vName;
    string _slowName;
    bool _isPlay = true;
    
    const string HORIZONTAL = "Horizontal";
    const string VERTICAL = "Vertical";
    const string HORIZONTAL2 = "Horizontal2";
    const string VERTICAL2 = "Vertical2";
    const string SLOW = "Slow";
    const string SLOW2 = "Slow2";

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        if (_pauseManager)
        {
            _pauseManager.OnPause += OnPause;
            _pauseManager.OnResume += OnResume;
        }

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
        if(_packController.gameObject.activeSelf == false)
        {
            switch (_playerType)
            {
                case PlayerType.Player1:
                    _rb.velocity = (_player1Pos - gameObject.transform.position) * _slowSpeed;
                    break;
                case PlayerType.Player2:
                    _rb.velocity = (_player2Pos - gameObject.transform.position) * _slowSpeed;
                    break;
            }
        }
        else if(_isPlay)
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
