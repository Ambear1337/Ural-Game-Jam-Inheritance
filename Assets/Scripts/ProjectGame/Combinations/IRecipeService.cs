namespace ProjectGame.Combinations
{
    public interface IRecipeService
    {
        bool TryGetResult(string item1, string item2, out string result, bool isTypeCheck);
    }
}