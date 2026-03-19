using UnityEngine;
using Sisus.Init;
using System.Collections.Generic;

namespace ProjectGame.Combinations
{
    [Service(typeof(IRecipeService), Instantiate = true)] 
    public class RecipeService: MonoBehaviour<CombinationsTable>, IRecipeService
    {
        private Dictionary<string, string> _typeRecipes = new();
        private Dictionary<string, string> _elementRecipes = new();

        // В Init мы можем загрузить данные.
        // Так как это Service, Init вызывается автоматически при старте игры.
        
        protected override void Init(CombinationsTable argument)
        {
            LoadRecipes();
        }

        private void LoadRecipes()
        {
            // Здесь ты можешь загрузить JSON из Resources, TextAsset или hardcoded строк.
            // Для примера предположим, что у тебя есть TextAsset в Resources
            var typesJson = Resources.Load<TextAsset>("Creatures/type_combinations").text;
            var elementsJson = Resources.Load<TextAsset>("Creatures/element_combinations").text;
            
            ParseJson(typesJson, _typeRecipes);
            ParseJson(elementsJson, _elementRecipes);
        }
        
        private void ParseJson(string json, Dictionary<string, string> targetDict)
        {
            if (string.IsNullOrEmpty(json)) return;

            try 
            {
                var table = JsonUtility.FromJson<CombinationsTable>(json);
                if (table?.Combinations == null) return;

                foreach (var entry in table.Combinations)
                {
                    // Создаем ключ в отсортированном порядке, чтобы Fire+Water == Water+Fire
                    string key = CreateSortedKey(entry.key1, entry.key2);
                    
                    if (!targetDict.ContainsKey(key))
                    {
                        targetDict[key] = entry.result;
                    }
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError($"[RecipeService] Ошибка парсинга JSON: {e.Message}");
            }
        }

        public bool TryGetResult(string item1, string item2, out string result, bool isTypeCheck)
        {
            var dict = isTypeCheck ? _typeRecipes : _elementRecipes;
            string key = CreateSortedKey(item1, item2);
            return dict.TryGetValue(key, out result);
        }

        private string CreateSortedKey(string a, string b) => string.Compare(a, b) < 0 ? $"{a}+{b}" : $"{b}+{a}";
    }
}