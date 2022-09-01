using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class BattleModel : MonoBehaviour
{
    public IntReactiveProperty Player1Point;
    public IntReactiveProperty Player2Point;

    [SerializeField]
    [Header("ƒpƒbƒN")]
    PackController _packController;


    void Awake()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnDestroy()
    {
        Player1Point.Dispose();
        Player2Point.Dispose();
    }
}
