using UnityEngine;

namespace ProjectGame.Combinations
{
    [CreateAssetMenu(fileName = "CreatureTypeRecipe", menuName = "Resources/Recipes/Types")]
    public class CreatureTypeRecipeTemplate: ScriptableObject
    {
        [SerializeField]
        private CreatureType _type1;
        [SerializeField]
        private CreatureType _type2;
        [SerializeField]
        private CreatureType _result;
        
        [HideInInspector]
        public CreatureType Type1 => _type1;
        [HideInInspector]
        public CreatureType Type2 => _type2;
        [HideInInspector]
        public CreatureType Result => _result;
    }
}