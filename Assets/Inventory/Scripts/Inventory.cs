using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ±³°üÁ´±í
/// </summary>
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/New Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> itemList = new List<Item>();
}
