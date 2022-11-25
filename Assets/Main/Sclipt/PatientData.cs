using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientData : MonoBehaviour
{
    [SerializeField, Header("治療に必要なItemの名前 健康な患者は(治療必要なし)と記入してください")] string[] _itemName;
    [SerializeField, Header("患者の状態")] string _state;

    [SerializeField, Header("間違ってもいい回数　健康な患者は１にしてください")] int _noGoodCount;
    [SerializeField,Header("合否判定スクリプトJuge")] Juge _juge;
    public string[] ItemsName { get => _itemName;}
    public int NoGoodCount { get => _noGoodCount;}
    public string State { get => _state;}

    private void Awake()
    {
        _juge = GameObject.FindObjectOfType<Juge>();
    }
    //アニメーションイベントを使用
    public void ObjectDestroy()
    {
        if (_juge.DestroyGO == null)
        {
            return;
        }
        else
        {
            Destroy(_juge.DestroyGO);
        }
    }
}
