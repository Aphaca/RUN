using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 每个皮肤的信息
/// Aphaca 2022.5.12
/// </summary>
namespace RUN
{
    public class CharacterInfo : MonoBehaviour
    {
        public Item item;
        //public string name;
        //public int price;
        public Inventory myCharatcer;
        public Inventory storeCharater;

        private void Update()
        {
            this.transform.Rotate(Vector3.up, 45 * Time.deltaTime, Space.Self);//物体自转代码
        }

        public void AddItem()
        {
            myCharatcer.itemList.Add(item);
            storeCharater.itemList.Remove(item);
            //InventoryManager.CreateNewItem(item);
            //InventoryManager.RefreshItem();
        }
        //public string name { set; get; }
        //public int price { set; get; }
    }
}