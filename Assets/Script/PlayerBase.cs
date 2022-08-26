using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBase : MonoBehaviour
{
    [SerializeField]
    [Header("スピード")]
    float _speed = 5;

    Rigidbody _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        OnMove();
    }

    void OnMove()
    {
        //_rb.AddForce(new Vector3(_m.x, 0f, _m.y) * _speed);
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");
        _rb.velocity = new Vector3(h,0f,v) * _speed;
    }
    
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
