using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class PackController : MonoBehaviour
{
    [SerializeField]
    [Header("バトルモデル")]
    BattleModel _battleModel;

    [SerializeField]
    [Header("パックが出てくる時のスピード")]
    float _speed = 3;

    Rigidbody _rb;
    Collider _collider;
    Vector3 _velocity;
    Vector3 _angularVelocity;
    PlayerType _endGoal;

    const int ONE_SECOND = 1000;
    const int ZERO_P_THREE_SECONDS = 300;
    const float PACK_HEIGHT = 0.121f;
    const float PACK_DEPTH = 5f;
    const float ONE = 1f;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        PauseManager.Instance.OnPause += OnPause;
        PauseManager.Instance.OnResume += OnResume;
    }

    async private void OnEnable()
    {
        switch (_endGoal)
        {
            case PlayerType.Player1:
                gameObject.transform.position = new Vector3(ONE, PACK_HEIGHT, PACK_DEPTH);
                _rb.velocity = new Vector3(ONE, 0f, -ONE).normalized * _speed;
                break;
            case PlayerType.Player2:
                gameObject.transform.position = new Vector3(-ONE, PACK_HEIGHT, PACK_DEPTH);
                _rb.velocity = new Vector3(-ONE, 0f, -ONE).normalized * _speed;
                break;
        }

        await Task.Delay(ZERO_P_THREE_SECONDS);
        _collider.isTrigger = false;    
    }

    async void OnDisable()
    { 
        _velocity = Vector3.zero;
        _angularVelocity = Vector3.zero;
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        _collider.isTrigger = true;
        await Task.Delay(ONE_SECOND);
        if (_battleModel.Judg.Value != PlayerType.Empty) return;
        gameObject.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out GoalEffect goalEffect))
        {
            switch (goalEffect.PlayerType)
            {
                case PlayerType.Player1:
                    _endGoal = PlayerType.Player1;
                    _battleModel.PlusPoint(PlayerType.Player1);
                    break;
                case PlayerType.Player2:
                    _endGoal = PlayerType.Player2;
                    _battleModel.PlusPoint(PlayerType.Player2);
                    break;
            }       
        }
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
