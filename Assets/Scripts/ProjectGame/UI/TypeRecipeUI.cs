using UnityEngine;

namespace ProjectGame.UI
{
    public class TypeRecipeUI: MonoBehaviour, IRecipeUI
    {
        [SerializeField] private CreatureType _creatureType;
        public CreatureType CreatureType => _creatureType;
    }
}