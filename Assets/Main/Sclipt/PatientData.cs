using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientData : MonoBehaviour
{
    [SerializeField, Header("���ÂɕK�v��Item�̖��O ���N�Ȋ��҂�(���ÕK�v�Ȃ�)�ƋL�����Ă�������")] string[] _itemName;
    [SerializeField, Header("���҂̏��")] string _state;

    [SerializeField, Header("�Ԉ���Ă������񐔁@���N�Ȋ��҂͂P�ɂ��Ă�������")] int _noGoodCount;
    [SerializeField,Header("���۔���X�N���v�gJuge")] Juge _juge;
    public string[] ItemsName { get => _itemName;}
    public int NoGoodCount { get => _noGoodCount;}
    public string State { get => _state;}

    private void Awake()
    {
        _juge = GameObject.FindObjectOfType<Juge>();
    }
    //�A�j���[�V�����C�x���g���g�p
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
