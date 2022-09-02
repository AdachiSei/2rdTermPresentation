using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalEffect : MonoBehaviour
{
    public PlayerType PlayerType => _playerType;

    [SerializeField]
    [Header("�S�[��")]
    PlayerType _playerType;

    [SerializeField]
    [Header("�S�[�����̃G�t�F�N�g")]
    ParticleSystem _particle;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
    }
}
