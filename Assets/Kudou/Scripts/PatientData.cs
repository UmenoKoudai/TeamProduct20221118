using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientData : MonoBehaviour
{
    [SerializeField, Header("治療に必要なItemの名前")] string[] _itemName;
    [SerializeField, Header("患者の状態")] string _state;
    

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
