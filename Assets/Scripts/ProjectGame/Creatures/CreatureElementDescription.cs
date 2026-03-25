using UnityEngine;

namespace ProjectGame.Creatures
{
    [CreateAssetMenu(fileName = "CreatureElementDescription", menuName = "Creatures/CreatureElementDescription")]
    public class CreatureElementDescription: ScriptableObject
    {
        [SerializeField] private Sprite _creatureElementSprite;
        public Sprite CreatureElementSprite => _creatureElementSprite;
        [SerializeField] private CreatureElement _creatureElement;
        public CreatureElement CreatureElement => _creatureElement;
    }
}
