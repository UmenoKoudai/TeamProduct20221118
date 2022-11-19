using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientData : MonoBehaviour
{
    [SerializeField, Header("¡—Ã‚É•K—v‚ÈItem‚Ì–¼‘O")] string[] _itemName;
    [SerializeField, Header("Š³Ò‚Ìó‘Ô")] string _state;

    [SerializeField, Header("ŠÔˆá‚Á‚Ä‚à‚¢‚¢‰ñ”")] int _noGoodCount; 
    public string[] ItemsName { get => _itemName;}
    public int NoGoodCount { get => _noGoodCount;}
    public string State { get => _state;}
}
