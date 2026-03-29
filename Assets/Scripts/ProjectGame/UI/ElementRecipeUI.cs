using UnityEngine;

namespace ProjectGame.UI
{
    public class ElementRecipeUI: MonoBehaviour, IRecipeUI
    {
        [SerializeField] private CreatureElement _creatureElement;
        public CreatureElement CreatureElement => _creatureElement;
    }
}