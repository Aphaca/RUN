using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
/// <summary>
/// 购买皮肤
/// Aphaca
/// </summary>
namespace RUN
{
	public class CharacterPreview : MonoBehaviour
	{
		public Inventory storeCharacter;
		public TMP_Text charNameText;
		//public Text camRotateXText;

		public RuntimeAnimatorController[] animController;
		public GameObject[] characters;

		Vector3 instantiatePos = new Vector3(0, 0, 0);
		Quaternion instantiateRot = new Quaternion(0, 0, 0, 1);
		Renderer[] rend;

		public int charIndex, animIndex;
		public int charCount, animCount;

		public GameObject buttonBuy;


		void Start()
		{
			//camMove = Camera.main.GetComponent<CameraMovement>();
			//RotateCam ();
		}

		// Use this for initialization
		void Awake()
		{
			RefreshList();
		}

		public void NextChar()
		{

			rend = characters[charIndex].GetComponentsInChildren<Renderer>();
			foreach (Renderer r in rend)
			{
				r.enabled = false;
			}

			if (charIndex >= charCount - 1)
				charIndex = 0;
			else
				++charIndex;

			rend = characters[charIndex].GetComponentsInChildren<Renderer>();
			foreach (Renderer r in rend)
			{
				r.enabled = true;
			}
			//charNameText.text = charNames[charIndex];
			RefreshInfo();
		}

		public void PrevChar()
		{

			rend = characters[charIndex].GetComponentsInChildren<Renderer>();
			foreach (Renderer r in rend)
			{
				r.enabled = false;
			}

			if (charIndex <= 0)
				charIndex = charCount - 1;
			else
				--charIndex;

			rend = characters[charIndex].GetComponentsInChildren<Renderer>();
			foreach (Renderer r in rend)
			{
				r.enabled = true;
			}
			//charNameText.text = charNames[charIndex];
			RefreshInfo();
		}

		public void NextAnim()
		{

			if (animIndex >= animCount - 1)
				animIndex = 0;
			else
				++animIndex;

			for (int i = 0; i < charCount; i++)
			{
				characters[i].GetComponent<Animator>().runtimeAnimatorController = animController[animIndex];
			}
		}

		public void PrevAnim()
		{

			if (animIndex <= 0)
				animIndex = animCount - 1;
			else
				--animIndex;

			for (int i = 0; i < charCount; i++)
			{
				characters[i].GetComponent<Animator>().runtimeAnimatorController = animController[animIndex];
			}
		}

		public void RefreshInfo()//更新信息
        {
			charNameText.text = characters[charIndex].GetComponent<CharacterInfo>().item.itemName + "  " + characters[charIndex].GetComponent<CharacterInfo>().item.itemPrice;
		}

		public void ClearAll()
        {
			for(int i = 0; i < characters.Length; i++)
            {
				Destroy(characters[i]);
            }
        }

		public void RefreshList()
        {
			ClearAll();
			if (characters != null)
			{
				charIndex = 0;
				animIndex = 0;

				charCount = storeCharacter.itemList.Count;
				animCount = animController.Length;

				characters = new GameObject[charCount];

				for (int i = 0; i < storeCharacter.itemList.Count; i++)
				{
					characters[i] = storeCharacter.itemList[i].itemPrefab;
				}

				foreach (GameObject c in characters)
				{
					characters[charIndex] = Instantiate(c, instantiatePos, instantiateRot) as GameObject;
					characters[charIndex].transform.parent = gameObject.transform;

					characters[charIndex].GetComponent<Animator>().runtimeAnimatorController = animController[animIndex];

					//set character render to false except first character
					rend = characters[charIndex].GetComponentsInChildren<Renderer>();
					foreach (Renderer r in rend)
					{
						//Debug.Log(charIndex);
						if (charIndex != 0)
							r.enabled = false;
						else
							r.enabled = true;
					}
					++charIndex;
				}

				charIndex = 0;
				charNameText.text = characters[charIndex].GetComponent<CharacterInfo>().item.itemName + "  " + characters[charIndex].GetComponent<CharacterInfo>().item.itemPrice;
			}
		}

		public void ReturnScene()
        {
			SceneManager.LoadScene("Store");
        }
	}
}
