using ProjectGame;
using ProjectGame.Combinations;
using ProjectGame.Creatures;
using Sisus.Init;
using UnityEngine;

[Service(FindFromScene = true)]
public class CreatureSpawner: MonoBehaviour<CreaturesPool, Player, Combiner, Shop>
{
    [SerializeField] private CreatureType[] _creatureDescriptions;
    [SerializeField] private CreatureElement[] _creatureElementsDescriptions;

    [SerializeField] private CreatureType[] _baseCreatureDescriptions;
    [SerializeField] private CreatureElement[] _baseElementsDescriptions;
    
    private CreaturesPool _creaturesPool;
    private Player _player;
    private Combiner _combiner;
    private Shop _shop;

    protected override void Init(CreaturesPool firstArgument, Player secondArgument, Combiner combiner, Shop shop)
    {
        _creaturesPool = firstArgument;
        _player = secondArgument;
        _combiner = combiner;
        _shop = shop;
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
        
        creature.SetupCreature(GetRandomBaseCreatureDescription(), GetRandomBaseCreatureElementDescription(), 1, 1, 1);
        
        _player.Inventory.AddItem(creature);
    }

    public CreatureType FindCreatureDescriptionByCreatureType(CreatureType type)
    {
        for (int i = 0; i < _creatureDescriptions.Length; i++)
        {
            if (_creatureDescriptions[i].CreatureType == type) return _CreatureType[i];
        }
        
        Debug.LogError("No creature type description found!");
        return null;
    }
    
    public CreatureElementDescription FindCreatureElementDescriptionByCreatureElement(CreatureElement element)
    {
        for (int i = 0; i < _creatureElementsDescriptions.Length; i++)
        {
            if (_creatureElementsDescriptions[i].CreatureElement == element) 
                return _creatureElementsDescriptions[i];
        }
        
        return null;
    }
    
    private CreatureDescription GetRandomBaseCreatureDescription()
    {
        int randomIndex = Random.Range(0, _baseCreatureDescriptions.Length);
        
        if (_baseCreatureDescriptions[randomIndex] == null) Debug.LogError("Описание существа не найдено!");

        return _baseCreatureDescriptions[randomIndex];
    }
    
    private CreatureDescription GetRandomCreatureDescription()
    {
        int randomIndex = Random.Range(0, _creatureDescriptions.Length);
        
        if (_creatureDescriptions[randomIndex] == null) Debug.LogError("Описание существа не найдено!");

        return _creatureDescriptions[randomIndex];
    }

    private CreatureElementDescription GetRandomCreatureElementDescription()
    {
        int randomIndex = Random.Range(0, _creatureElementsDescriptions.Length);
        
        return _creatureElementsDescriptions[randomIndex];
    }
    
    private CreatureElementDescription GetRandomBaseCreatureElementDescription()
    {
        int randomIndex = Random.Range(0, _baseElementsDescriptions.Length);
        
        return _baseElementsDescriptions[randomIndex];
    }
}
