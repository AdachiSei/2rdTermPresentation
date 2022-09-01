using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PackController : MonoBehaviour
{
    Rigidbody _rb;

    Vector3 _velocity;
    Vector3 _angularVelocity;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        PauseManager.Instance.OnPause += () => OnPause();
        PauseManager.Instance.OnResume += () => OnResume();
    }

    void OnPause()
    {
        _velocity = _rb.velocity;
        _angularVelocity = _rb.angularVelocity;
        _rb.constraints = RigidbodyConstraints.FreezeAll;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void OnResume()
    {
        _rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        _rb.velocity = _velocity;
        _rb.angularVelocity = _angularVelocity;
    }
}
