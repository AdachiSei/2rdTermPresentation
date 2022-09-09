using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextBoothView : MonoBehaviour
{
    [SerializeField]
    [Header("次のブースに行くためのButton")]
    List<NextBooth> nextBooth = new();


    [System.Serializable]
    public class NextBooth
    {
        public Button Button => _nextBoothButton;

        [SerializeField]
        [Tooltip("ボタンの名前")]
        string _buttonName;

        [SerializeField]
        Button _nextBoothButton;

    }
}
