using ProjectGame.UI;
using Sisus.Init;
using UnityEngine;

namespace ProjectGame
{
    [Service(FindFromScene = true)]
    public class SellService: MonoBehaviour<CreatureSpawner>
    {
        [SerializeField] private SellInventory _inventory;

        private CreatureSpawner _spawner;
        
        protected override void Init(CreatureSpawner argument)
        {
            _spawner = argument;
        }

        public void SellCreature(Creature creature)
        {
            for (int i = 0; i < _inventory.Slots.Count; i++)
            {
                if (_inventory.Slots[i] != null)
                {
                    _spawner.ReleaseCreature(_inventory.Slots[i].Creature);
                    _inventory.Slots[i].Clear();
                }
            }
        }
    }
}