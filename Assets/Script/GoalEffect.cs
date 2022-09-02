using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalEffect : MonoBehaviour
{
    public PlayerType PlayerType => _playerType;

    [SerializeField]
    [Header("ゴール")]
    PlayerType _playerType;

    [SerializeField]
    [Header("ゴール時のエフェクト")]
    ParticleSystem _particle;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
    }
}
