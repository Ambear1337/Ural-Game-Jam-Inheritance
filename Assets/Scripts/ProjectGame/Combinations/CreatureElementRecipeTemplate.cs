using UnityEngine;

namespace ProjectGame.Combinations
{
    [CreateAssetMenu(fileName = "CreatureElementRecipe", menuName = "Resources/Recipes/Elements")]
    public class CreatureElementRecipeTemplate: ScriptableObject
    {
        [SerializeField]
        private CreatureElement _element1;
        [SerializeField]
        private CreatureElement _element2;
        [SerializeField]
        private CreatureElement _result;
        
        [HideInInspector]
        public CreatureElement Element1 => _element1;
        [HideInInspector]
        public CreatureElement Element2 => _element2;
        [HideInInspector]
        public CreatureElement Result => _result;
    }
}