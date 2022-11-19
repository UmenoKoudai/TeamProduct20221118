using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField, Header("Item–¼")] string _itemName;
    public string ItemName { get => _itemName; }
    
    void Start()
    {
        this.gameObject.name = _itemName;
    }
}
