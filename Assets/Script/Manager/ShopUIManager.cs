using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : SingletonMonoBehaviour<ShopUIManager>
{
    [SerializeField]
    [Header("�w�����ɕ\�������e�L�X�g�̕\������")]
    [Range(0.1f, 10f)]
    float _displaySeconds = 1f;

    [SerializeField]
    [Header("�X�}�b�V���[���̃e�L�X�g")]
    Text _smasherNameText;

    [SerializeField]
    [Header("�����̃e�L�X�g")]
    Text _explainText;

    [SerializeField]
    [Header("�w���m�F�̃e�L�X�g")]
    Text _isBuyText;

    [SerializeField]
    [Header("�w�������Ƃ��̃e�L�X�g")]
    Text _boughtText;

    [SerializeField]
    [Header("�����̃p�l��")]
    Image _explainPanel;

    [SerializeField]
    [Header("�w���̃p�l��")]
    Image _isBuyPanel;

    [SerializeField]
    [Header("������A�C�e��")]
    ItemsData _items;

    /// <summary>�������Ƃ����A�C�e���̋L�^</summary>
    SmasherType _itemType;
    const string IS_BUY = "���w�����܂���?";
    const string BOUGHT = "���w�����܂���";

    /// <summary>�A�C�e��������UI</summary>
    public void ShopItemExplain(SmasherType type)
    {
        //���ꂼ��A�C�e�����A�������A���A�x��ύX
        _smasherNameText.text = _items.Data.FirstOrDefault(x => x.Type == type).Name;
        _explainText.text = _items.Data.FirstOrDefault(x => x.Type == type).Explain;
    }

    /// <summary>�A�C�e�������p�l����\����\������</summary>
    public void ShopItemExplainSetActive(bool _active)
    {
        _explainPanel.gameObject.SetActive(_active);
    }

    /// <summary>�A�C�e�����w�����邩�ǂ���</summary>
    public void ShopItemIsBuy(SmasherType type)
    {
        _itemType = type;
        //�w����ʂ̂̃e�L�X�g��ύX
        _isBuyText.text = _items.Data.FirstOrDefault(x => x.Type == type).Name + IS_BUY;
        //�p�l����\��
        _isBuyPanel.gameObject.SetActive(true);
    }

    /// <summary>�A�C�e���w���p</summary>
    public async void ShopItemBought()
    {
        _isBuyPanel.gameObject.SetActive(false);
        _boughtText.text = _items.Data.FirstOrDefault(x => x.Type == _itemType).Name + BOUGHT;
        _boughtText.gameObject.SetActive(true);
        await Task.Delay(1000);
        _boughtText.gameObject.SetActive(false);
    }

    public void ShopItemDontBought()
    {
        _isBuyPanel.gameObject.SetActive(false);
    }
}
