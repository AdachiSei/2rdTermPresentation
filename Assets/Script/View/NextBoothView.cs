using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextBoothView : MonoBehaviour
{
    [SerializeField]
    [Header("���̃u�[�X�ɍs�����߂�Button")]
    List<NextBooth> nextBooth = new();


    [System.Serializable]
    public class NextBooth
    {
        public Button Button => _nextBoothButton;

        [SerializeField]
        [Tooltip("�{�^���̖��O")]
        string _buttonName;

        [SerializeField]
        Button _nextBoothButton;

    }
}
