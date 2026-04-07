using ProjectGame;
using ProjectGame.Combinations;
using ProjectGame.Creatures;
using Sisus.Init;
using UnityEngine;

[Service(FindFromScene = true)]
public class CreatureSpawner: MonoBehaviour<CreaturesPool, Player, Combiner, Shop, RecipeService>
{
    private CreaturesPool _creaturesPool;
    private Player _player;
    private Combiner _combiner;
    private Shop _shop;
    private RecipeService _recipeService;

    protected override void Init(CreaturesPool firstArgument, Player secondArgument, Combiner combiner, Shop shop, RecipeService recipeService)
    {
        _creaturesPool = firstArgument;
        _player = secondArgument;
        _combiner = combiner;
        _shop = shop;
        _recipeService = recipeService;
    }

    public void SpawnCombinedCreature(CreatureType type, CreatureElement element, int size, int intelligence, int aggression)
    {
        _creaturesPool.Pool.Get(out var creature);
        creature.SetupCreature(type, element, size, intelligence, aggression);

        // Вместо CreateCombinedCreature теперь вызываем PlaceCombinedCreature
        _combiner.PlaceCombinedCreature(creature);
    }

    public void ReleaseCreature(Creature creature)
    {
        _creaturesPool.Pool.Release(creature);
    }

    public void ReleaseCreaturesAfterCombine(Creature creature1, Creature creature2)
    {
        _creaturesPool.Pool.Release(creature1);
        _creaturesPool.Pool.Release(creature2);
    }
 
    public void SpawnCreature(CreatureType type, CreatureElement element, int size, int intelligence, int aggression)
    {
        _creaturesPool.Pool.Get(out var creature);
        
        creature.SetupCreature(type, element, size, intelligence, aggression);
        
        _player.Inventory.AddItem(creature);
    }

    public void SpawnRandomCreature()
    {
        _creaturesPool.Pool.Get(out var creature);
        
        creature.SetupCreature(_recipeService.GetRandomCreatureType(), _recipeService.GetRandomCreatureElement(), 1, 1, 1);
        
        _player.Inventory.AddItem(creature);
    }
}
