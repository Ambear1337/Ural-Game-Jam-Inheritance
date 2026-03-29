using UnityEngine.EventSystems;

namespace ProjectGame.UI
{
    public class SellSlotUI: CreatureSlotUI
    {
        public override void OnDrop(PointerEventData eventData)
        {
            base.OnDrop(eventData);

            _shop.SellCreature(_slotData.Creature);
        }
    }
}
