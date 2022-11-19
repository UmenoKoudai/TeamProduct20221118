using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientData : MonoBehaviour
{
    [SerializeField, Header("���ÂɕK�v��Item�̖��O")] string[] _itemName;
    [SerializeField, Header("���҂̏��")] string _state;

    [SerializeField, Header("�Ԉ���Ă�������")] int _noGoodCount; 
    public string[] ItemsName { get => _itemName;}
    public int NoGoodCount { get => _noGoodCount;}
    public string State { get => _state;}
}
