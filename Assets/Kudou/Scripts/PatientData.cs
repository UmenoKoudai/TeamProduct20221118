using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientData : MonoBehaviour
{
    [SerializeField, Header("���ÂɕK�v��Item�̖��O")] string[] _itemName;
    [SerializeField, Header("���҂̏��")] string _state;

    [SerializeField, Header("�Ԉ���Ă�������")] int _noGoodCount;
    [SerializeField] Juge _juge;
    public string[] ItemsName { get => _itemName;}
    public int NoGoodCount { get => _noGoodCount;}
    public string State { get => _state;}

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
