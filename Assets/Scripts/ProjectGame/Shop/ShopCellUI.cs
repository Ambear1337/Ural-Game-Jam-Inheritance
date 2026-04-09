using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectGame.Shop
{
    public class ShopCellUI
    {
        private ShopCell _shopCell;

        [SerializeField] private Image _productImage;
        [SerializeField] private TextMeshProUGUI _productName;
        [SerializeField] private TextMeshProUGUI _productPrice;

        public void SetupShopCell(ShopCell shopCell)
        {
            _shopCell = shopCell;

            _productImage.sprite = shopCell.Item.ItemSprite;
            _productName.text = shopCell.Item.ItemName;
        }
    }
}