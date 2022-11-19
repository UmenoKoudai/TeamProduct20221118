using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientData : MonoBehaviour
{
    [SerializeField, Header("治療に必要なItemの名前")] string[] _itemName;
    [SerializeField, Header("患者の状態")] string _state;

    [SerializeField, Header("間違ってもいい回数")] int _noGoodCount; 
    public string[] ItemsName { get => _itemName;}
    public int NoGoodCount { get => _noGoodCount;}
    public string State { get => _state;}
}
