using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientData : MonoBehaviour
{
    [SerializeField, Header("���ÂɕK�v��Item�̖��O")] string[] _itemName;
    [SerializeField, Header("���҂̏��")] string _state;
    

    public string[] ItemsName { get => _itemName;}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
