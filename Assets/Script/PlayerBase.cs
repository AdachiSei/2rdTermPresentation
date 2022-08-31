using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBase : MonoBehaviour
{
    [SerializeField]
    [Header("プレイヤーのタイプ")]
    PlayerType _playerType;

    [SerializeField]
    [Header("スピード")]
    float _speed = 15;

    Rigidbody _rb;

    string _hName;
    string _vName;
    
    const string HORIZONTAL = "Horizontal";
    const string VERTICAL = "Vertical";
    const string HORIZONTAL2 = "Horizontal2";
    const string VERTICAL2 = "Vertical2";

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        switch(_playerType)
        {
            case PlayerType.Player1:
                _hName = HORIZONTAL;
                _vName = VERTICAL;
                break;
            case PlayerType.Player2:
                _hName = HORIZONTAL2;
                _vName = VERTICAL2;
                break;
            default:
                Debug.Log("プレイヤーのタイプを設定してください");
                break;
        }
    }

    protected virtual void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;

        Move();
    }

    protected virtual void Move()
    {
        float h = Input.GetAxisRaw(_hName);
        float v = Input.GetAxisRaw(_vName);
        _rb.velocity = new Vector3(h, 0f, v).normalized * _speed;
    }

    //void MoveForMouse()
    //{
    //    //_rb.AddForce(new Vector3(_m.x, 0f, _m.y) * _speed);
    //    float h = Input.GetAxis("Mouse X");
    //    float v = Input.GetAxis("Mouse Y");
    //    _rb.velocity = new Vector3(h,0f,v) * _speed;
    //}

    //public void Move(InputAction.CallbackContext context)
    //{
    //    _m = context.ReadValue<Vector2>();
    //    Debug.Log(_m);
    //}

    //public void MoveForMouse(InputAction.CallbackContext context)
    //{
    //    _m = context.ReadValue<Vector2>() / 25;
    //    Debug.Log(_m);
    //}

    //public void MoveForJoycon(InputAction.CallbackContext context)
    //{
    //    _m = context.ReadValue<Vector2>() / 25;
    //    Debug.Log(_m);
    //}
}
