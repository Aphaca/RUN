using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName ="Inventory/New Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public int itemPrice;
    public Sprite itemImage;
    public GameObject itemPrefab;
    public bool beBought;
    //public int itemHeld;
    [TextArea]
    public string itemDescription;

    //public bool itemCanBeMixed;
}
