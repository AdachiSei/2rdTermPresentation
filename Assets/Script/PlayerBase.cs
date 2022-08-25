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

        Move();
    }

    void Move()
    {
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");
        _rb.velocity = new Vector3(h,0f,v) * _speed;
    }
}
