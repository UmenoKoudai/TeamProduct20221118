using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Juge : MonoBehaviour
{
    Animator _patientAnim;
    [SerializeField] Button[] _buttons;
    [SerializeField] EventSystem eventSystem;
    [SerializeField] string[] _answerItems;
    int noGoodCountMax;
    int noGoodCountNow;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        ResetButton(false);
    }

    public void Jugement()
    {
        Item item = eventSystem.currentSelectedGameObject.GetComponent<Item>();

        if(i == _answerItems.Length - 1)
        {
            ResetButton(false);
        }
        else if(item.ItemName == _answerItems[i])
        {
            Debug.Log("‚ ‚Á‚Ä‚¢‚Ü‚·");
            i++;
        }
        else
        {
            noGoodCountNow++;
            Debug.Log("ŠÔˆá‚¦‚Ä‚¢‚Ü‚·");
            if(noGoodCountNow == noGoodCountMax)
            {
                ResetButton(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ResetButton(true);
        _answerItems = collision.GetComponent<PatientData>().ItemsName;
        noGoodCountMax = collision.GetComponent<PatientData>().NoGoodCount;
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        i = 0;
        noGoodCountNow = 0;
    }

    private void ResetButton(bool TrueFalse)
    {
        for(var i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].interactable = TrueFalse;
        }
    }







}
