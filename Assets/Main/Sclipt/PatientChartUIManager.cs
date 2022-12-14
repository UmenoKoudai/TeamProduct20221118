using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientChartUIManager : MonoBehaviour
{
    [SerializeField,Header("カルテ上にあるStateText")]Text _state;
    [SerializeField, Header("カルテ上にあるNeedItemText")] Text _needItemText;
    string[] _needItems;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _state.text = collision.GetComponent<PatientData>().State;
            _needItems = collision.GetComponent<PatientData>().ItemsName;
            for (int i = 0; i < _needItems.Length; i++)
            {
                _needItemText.text += $"{_needItems[i]} ";
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _needItemText.text = "";
            _state.text = "";
        }
    }
}
