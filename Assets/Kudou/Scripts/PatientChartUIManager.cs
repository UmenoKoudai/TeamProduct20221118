using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientChartUIManager : MonoBehaviour
{
    [SerializeField]Text _state;
    [SerializeField]Text _needItemText;
    string[] _needItems;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _state.text = collision.GetComponent<PatientData>().State;
        _needItems = collision.GetComponent<PatientData>().ItemsName;
        for (int i = 0; i < _needItems.Length; i++)
        {
            _needItemText.text += $"{_needItems[i]} ";
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
