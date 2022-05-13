using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace RUN
{
    public class Honor : MonoBehaviour
    {
        public Inventory honor;

        public void ReturnMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

}