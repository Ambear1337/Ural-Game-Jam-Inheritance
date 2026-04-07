using UnityEngine;

namespace ProjectGame.Creatures
{
    public class CreatureElement: ScriptableObject
    {
        [SerializeField] private string _creatureElementName;
        public string CreatureElementName => _creatureElementName;
        [SerializeField] private Sprite _creatureElementSprite;
        public Sprite CreatureElementSprite => _creatureElementSprite;
        [SerializeField] private int _cost;
    }
}
