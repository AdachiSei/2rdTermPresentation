using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PackController : MonoBehaviour
{
    Rigidbody _rb;

    Vector3 _vector3;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        PauseManager.Instance.OnPause += () => OnPause();
        PauseManager.Instance.OnResume += () => OnResume();
    }

    void OnPause()
    {
        _vector3 = _rb.velocity;
        _rb.constraints = RigidbodyConstraints.FreezePosition;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void OnResume()
    {
        _rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        _rb.velocity = _vector3;
    }
}
