using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    internal class Shop : MonoBehaviour
    {
        public Canvas Menu;


        private void Start()
        {
            Menu.gameObject.SetActive(false);
        }

        public void ChangeState()
        {
            Menu.gameObject.SetActive(!Menu.gameObject.active);
        }
    }
}
