using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : SingletonMonoBehaviour<ShopUIManager>
{
    [SerializeField]
    [Header("購入時に表示されるテキストの表示時間")]
    [Range(0.1f, 10f)]
    float _displaySeconds = 1f;

    [SerializeField]
    [Header("スマッシャー名のテキスト")]
    Text _smasherNameText;

    [SerializeField]
    [Header("説明のテキスト")]
    Text _explainText;

    [SerializeField]
    [Header("購入確認のテキスト")]
    Text _isBuyText;

    [SerializeField]
    [Header("購入したときのテキスト")]
    Text _boughtText;

    [SerializeField]
    [Header("説明のパネル")]
    Image _explainPanel;

    [SerializeField]
    [Header("購入のパネル")]
    Image _isBuyPanel;

    [SerializeField]
    [Header("買えるアイテム")]
    ItemsData _items;

    /// <summary>買おうとしたアイテムの記録</summary>
    SmasherType _itemType;
    const string IS_BUY = "を購入しますか?";
    const string BOUGHT = "を購入しました";

    /// <summary>アイテム説明のUI</summary>
    public void ShopItemExplain(SmasherType type)
    {
        //それぞれアイテム名、説明文、レア度を変更
        _smasherNameText.text = _items.Data.FirstOrDefault(x => x.Type == type).Name;
        _explainText.text = _items.Data.FirstOrDefault(x => x.Type == type).Explain;
    }

    /// <summary>アイテム説明パネルを表示非表示する</summary>
    public void ShopItemExplainSetActive(bool _active)
    {
        _explainPanel.gameObject.SetActive(_active);
    }

    /// <summary>アイテムを購入するかどうか</summary>
    public void ShopItemIsBuy(SmasherType type)
    {
        _itemType = type;
        //購入画面ののテキストを変更
        _isBuyText.text = _items.Data.FirstOrDefault(x => x.Type == type).Name + IS_BUY;
        //パネルを表示
        _isBuyPanel.gameObject.SetActive(true);
    }

    /// <summary>アイテム購入用</summary>
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
