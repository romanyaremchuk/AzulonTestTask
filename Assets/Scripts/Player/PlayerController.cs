using System;
using Currency;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Wallet _wallet;
        [SerializeField] private ShopController _shopController;
        
        private void Awake()
        {
            Global.RD<PlayerData>().Wallet = _wallet;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _shopController.TryBuy(_shopController.ShopEntries[0]);
            }
            
            if (Input.GetKeyDown(KeyCode.P))
            {
                _shopController.Sell(_shopController.ShopEntries[0]);
            }
        }
    }
}