using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientChartUIManager : MonoBehaviour
{
    Text _state;
    Text[] _needItem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _state.text = collision.GetComponent<PatientData>().State;
        //for (var i = 0; i < _needItem.Length; i++)
        //{
        //    _needItem[i].text = collision.GetComponent<PatientData>().ItemsName[i];
        //}
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
