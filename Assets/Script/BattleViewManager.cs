using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class BattleViewManager : MonoBehaviour
{
    [SerializeField]
    Button _button;

    void Start()
    {
        _button.onClick.AddListener(Test);
    }

    void Update()
    {
        
    }

    void Test()
    {
        Debug.Log("aaaa");
    }
}
