using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 单个物品
/// Aphaca
/// </summary>
namespace RUN
{
    public class Slot : MonoBehaviour
    {
        public Item slotItem;
        public Image slotImage;
        public int slotPrice;
        public string slotDescription;
        //public bool slotCanMix;

        public void ItemOnClicked()
        {
            InventoryManager.UpdageItemInfo(slotItem.itemDescription);
        }
    }

}