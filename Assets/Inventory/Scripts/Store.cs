using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
/// <summary>
/// �̵�
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
        public CharacterInfo[] PlayerCharacter;//�����ɫ���������� 3+...
        public Slot[] Tool;
        public GameObject charactorPreview;
        //Renderer[] render;
        //public int[] Tool_Price;

        public int current;//��ǰ�������Ʒ
        public int current_Character;//��ǰ����Ľ�ɫ

        public TMP_Text[] tool_Txt;
        //public TMP_Text tool2;
        //public TMP_Text tool3;

        public TMP_Text coins;

        #region ���򹤾�
        public void Confirm_Tool(int i)//ȷ�Ϲ�������
        {
            panelConfirm.SetActive(true);
            current = i;
            //current_Character = charactorPreview.GetComponent<CharacterPreview>().charIndex;
            ShowInfo_Tool();
        }

        public void Cost_Tool()//���� ȷ�Ϲ�����Ҽ���
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
            coins.text = "��ң�" + coin.ToString();
            //myTool.itemList.Add(Tool[current].slotItem);
        }

        public void ShowInfo_Tool()//չʾ���ߡ�Ƥ����Ϣ
        {
            description.text = Tool[current].slotItem.itemName + "(" + Tool[current].slotDescription + ") ���� " + Tool[current].slotPrice + " ���";
            //description.text = PlayerCharacter[current].name + " ���� " + PlayerCharacter[current_Character].price;
        }
        #endregion

        #region ����Ƥ��
        public void Confirm_Char()//ȷ�Ϲ�������
        {
            panelConfirm.SetActive(true);
            //current = i;
            current_Character = charactorPreview.GetComponent<CharacterPreview>().charIndex;
            ShowInfo_Char();
        }
        public void Cost_Char()//���� ȷ�Ϲ�����Ҽ���
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

        public void ShowInfo_Char()//չʾ���ߡ�Ƥ����Ϣ
        {
            //description.text = Tool[current].slotItem.itemName + " " + Tool[current].slotDescription + " ���� " + Tool[current].slotPrice;
            description.text = storeCharacterList.itemList[current_Character].name + " ���� " + storeCharacterList.itemList[current_Character].itemPrice + " ���";
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
