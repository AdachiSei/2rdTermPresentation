using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ChangeUIManager : MonoBehaviour
{
    [SerializeField]
    [Header("テキストが流れるスピード")]
    [Range(0f,1f)]
    float _speed = 0.03f;

    [SerializeField]
    [Header("全てのUI")]
    List<Booths> _booths = new();

    [SerializeField]
    [Header("所持金のテキスト")]
    Text _moneyText;

    [SerializeField]
    [Header("場所の名前のテキスト")]
    Text _boothNameText;

    [SerializeField]
    [Header("下の説明テキスト")]
    Text _explainText;

    [SerializeField]
    [Header("下の説明パネル")]
    Image _explainPanel;

    /// <summary>一回だけ</summary>
    bool _isFirst;
    /// <summary>通った道の記録</summary>
    Stack<BoothType> _boothTypes = new Stack<BoothType>();

    void Start() 
    {
        //場所テキストの名前を変更
        _boothNameText
            .text = _booths
                        .FirstOrDefault(x => x
                        .BoothType == BoothType
                        .Home)
                        .BoothName;
        //現在のブースタイプを保存
        _boothTypes.Push(BoothType.Home);
        StartCoroutine(Explain(_booths
            .FirstOrDefault(x => x
            .BoothType == BoothType.Home)
            .Message));
    }

    /// <summary>ショップメニューを表示</summary>
    public void NextMenu(BoothType boothType)
    {
        //次のUIを表示する
        _booths
            .First(x => x
            .BoothType == boothType)
            .SetActive(true);
        //前のUIを非表示する
        _booths.First(x => x
            .BoothType == _boothTypes
            .Peek())
            .SetActive(false);
        //現在の状態(移動した後の)を保存
        _boothTypes.Push(boothType);
        //下の説明テキストを変更
        StopAllCoroutines();
        StartCoroutine(Explain(_booths
            .FirstOrDefault(x => x
            .BoothType == _boothTypes
            .Peek())
            .Message));
        //場所テキストの名前を変更
        _boothNameText
            .text = _booths
                        .FirstOrDefault(x => x
                        .BoothType == boothType)
                        .BoothName;
        _isFirst = true;
    }

    /// <summary>戻る</summary>
    public void BackMenu()
    {
        //今のUIを非表示する
        _booths.FirstOrDefault(x => x
            .BoothType == _boothTypes
            .Peek())
            .SetActive(false);
        if(_boothTypes.Peek() != BoothType.Home)
            _boothTypes.Pop();
        //前のUIを表示
        _booths
            .FirstOrDefault(x => x
            .BoothType == _boothTypes
            .Peek())
            .SetActive(true);

        //下の説明テキストを変更
        if(_isFirst)
        {
            StopAllCoroutines();
            StartCoroutine(Explain(_booths
                .FirstOrDefault(x => x
                .BoothType == _boothTypes
                .Peek())
                .Message));
        }
        if (_boothTypes.Peek() == BoothType.Home)
        {
            _isFirst = false;
        }
        //場所テキストの名前を変更
        _boothNameText
            .text = _booths
                        .FirstOrDefault(x => x
                        .BoothType == _boothTypes
                        .Peek())
                        .BoothName;
    }

    /// <summary>テキストを1文字ずつ時間差で表示する</summary>
    IEnumerator Explain(string text)
    {
        //空にする
        _explainText.text = "";
        //一文字ずつ表示
        for(var t = 0; t < text.Length; t++)
        {
            _explainText.text += _booths.FirstOrDefault(x => x.BoothType == _boothTypes.Peek()).Message[t];
            yield return new WaitForSeconds(_speed);
        }
    }

    [System.Serializable]
    public class Booths
    {
        public BoothType BoothType => _boothType;
        public string BoothName => _boothName;
        public string Message => _message;
        public GameObject UI => _ui;

        [SerializeField]
        [Tooltip("名前")]
        string _name;

        [SerializeField]
        [Tooltip("表示したい店の名前")]
        string _boothName;

        [SerializeField]
        [Tooltip("表示したいメッセージ")]
        string _message;

        [SerializeField]
        [Tooltip("店の種類")]
        BoothType _boothType;

        [SerializeField]
        [Tooltip("UI")]
        GameObject _ui;

        public void SetActive(bool set)
        {
            _ui.gameObject.SetActive(set);
        }
    }
}