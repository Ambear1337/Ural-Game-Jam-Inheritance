using UnityEngine;
using UnityEngine.UI;

namespace ProjectGame
{
    [CreateAssetMenu(fileName = "CreatureDescription", menuName = "Creatures/CreatureDescription")]
    public class CreatureDescription: ScriptableObject
    {
        [SerializeField] private Sprite _creatureSprite;
        public Sprite CreatureSprite => _creatureSprite;
        [SerializeField] private CreatureType _creatureType;
        public CreatureType CreatureType => _creatureType;
    }
}