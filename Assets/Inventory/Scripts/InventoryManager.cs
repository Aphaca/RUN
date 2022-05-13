using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/// <summary>
/// 将物体显示在UI界面上
/// Aphaca
/// </summary>
namespace RUN
{
    public class InventoryManager : MonoBehaviour
    {
        static InventoryManager instance;

        public Inventory myBag;
        public GameObject slotGrid;
        public Slot slotPrefab;
        public TMP_Text itemInformation;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(this);
            }
            instance = this;
        }

        //private void OnEnable()
        //{
        //    //RefreshItem();
        //    instance.itemInformation.text = "";
        //}

        public static void UpdageItemInfo(string itemDescription)
        {
            //Debug.LogWarning("+++");
            instance.itemInformation.text = itemDescription;
        }

        public static void CreateNewItem(Item item)
        {
            //Debug.LogWarning("****");
            Slot newSlot = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
            //Debug.LogWarning("+++++");
            newSlot.gameObject.transform.SetParent(instance.slotGrid.transform);
            newSlot.slotItem = item;
            newSlot.slotImage.sprite = item.itemImage;
            newSlot.slotDescription = item.itemDescription;
            //newItem.slotCanMix = item.itemCanBeMixed;
        }
    }
}
