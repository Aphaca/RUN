using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
/// <summary>
/// 商店
/// Aphaca
/// </summary>
namespace RUN
{
    public class Store : MonoBehaviour
    {
        public Inventory storeCharacterList;
        public Inventory storeTool;
        public Inventory myCharacterList;
        public Inventory myTool;
        public TMP_Text description;
        public GameObject panelConfirm;
        public CharacterInfo[] PlayerCharacter;//动物角色，自行增加 3+...
        public Slot[] Tool;
        public GameObject charactorPreview;
        //Renderer[] render;
        //public int[] Tool_Price;

        public int current;//当前购买的物品
        public int current_Character;//当前购买的角色

        public TMP_Text[] tool_Txt;
        //public TMP_Text tool2;
        //public TMP_Text tool3;

        public TMP_Text coins;

        #region 购买工具
        public void Confirm_Tool(int i)//确认购买的面板
        {
            panelConfirm.SetActive(true);
            current = i;
            //current_Character = charactorPreview.GetComponent<CharacterPreview>().charIndex;
            ShowInfo_Tool();
        }

        public void Cost_Tool()//工具 确认购买后金币减少
        {
            int coin = 0;
            PlayerPrefs.GetInt("Coin", coin);
            if (coin < Tool[current].slotItem.itemPrice)
            {
                return;
            }
            PlayerPrefs.SetInt("Coin", coin - Tool[current].slotPrice);
            int num = 0;
            if (current == 0)
            {
                PlayerPrefs.GetInt("Magnet", num);
                PlayerPrefs.SetInt("Magnet", num++);
            }else
                if (current == 1)
            {
                PlayerPrefs.GetInt("Double", num);
                PlayerPrefs.SetInt("Double", num++);
                //tool2.text = num.ToString();
            }
            else
            {
                PlayerPrefs.GetInt("Shield", num);
                PlayerPrefs.SetInt("Shield", num++);
            }
            tool_Txt[current].text = num.ToString();
            coins.text = "金币：" + coin.ToString();
            //myTool.itemList.Add(Tool[current].slotItem);
        }

        public void ShowInfo_Tool()//展示道具、皮肤信息
        {
            description.text = Tool[current].slotItem.itemName + "(" + Tool[current].slotDescription + ") 花费 " + Tool[current].slotPrice + " 金币";
            //description.text = PlayerCharacter[current].name + " 花费 " + PlayerCharacter[current_Character].price;
        }
        #endregion

        #region 购买皮肤
        public void Confirm_Char()//确认购买的面板
        {
            panelConfirm.SetActive(true);
            //current = i;
            current_Character = charactorPreview.GetComponent<CharacterPreview>().charIndex;
            ShowInfo_Char();
        }
        public void Cost_Char()//工具 确认购买后金币减少
        {
            int coin = 0;
            PlayerPrefs.GetInt("Coin", coin);
            PlayerPrefs.SetInt("Coin", coin - storeCharacterList.itemList[current_Character].itemPrice);
            storeCharacterList.itemList.Remove(storeCharacterList.itemList[current_Character]);
            myCharacterList.itemList.Add(storeCharacterList.itemList[current_Character]);
            //render = storeCharacterList.itemList[current_Character].itemPrefab.GetComponentsInChildren<Renderer>();
            //foreach (Renderer r in render)
            //{
            //    r.enabled = false;
            //}
            charactorPreview.GetComponent<CharacterPreview>().RefreshList();
        }

        public void ShowInfo_Char()//展示道具、皮肤信息
        {
            //description.text = Tool[current].slotItem.itemName + " " + Tool[current].slotDescription + " 花费 " + Tool[current].slotPrice;
            description.text = storeCharacterList.itemList[current_Character].name + " 花费 " + storeCharacterList.itemList[current_Character].itemPrice + " 金币";
        }
        #endregion

        public void ReturnMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void MyBag()
        {
            SceneManager.LoadScene("MyBag");
        }
    }
}
