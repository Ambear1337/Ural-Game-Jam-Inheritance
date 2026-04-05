using UnityEngine;
using UnityEngine.UI;

namespace ProjectGame.UI.InventorySystem
{
    public class Item: MonoBehaviour
    {
        protected Sprite _itemSprite;
        public Sprite ItemSprite => _itemSprite;
    }
}