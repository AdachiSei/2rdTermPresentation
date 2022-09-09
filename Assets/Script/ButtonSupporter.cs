using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class ButtonSupporter : MonoBehaviour
{
    [SerializeField]
    [Header("次に行きたい店の種類(移動用)")]
    BoothType _boothType;
    
    //[SerializeField]
    //[Header("アイテムのタイプ(ショップのボタン用)")]
    //ItemType _itemType;

    public void NextMenu() => ChangeUIManager.Instance.NextMenu(_boothType);
    public void BackMenu() => ChangeUIManager.Instance.BackMenu();
    //public void ShopItemExplain() => HomeUIManager.Instance.ShopItemExplain(_itemType);
    //public void ShopItemExplainSetActive(bool _active) => HomeUIManager.Instance.ShopItemExplainSetActive(_active);
    //public void ShopItemIsBuy() => HomeUIManager.Instance.ShopItemIsBuy(_itemType);
    //public void ShopItemBought() => HomeUIManager.Instance.ShopItemBought();
    //public void ShopItemDontBought() => HomeUIManager.Instance.ShopItemDontBought();
}
