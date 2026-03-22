using ProjectGame;
using Sisus.Init;
using UnityEngine;

[Service(FindFromScene = true)]
public class CreatureSpawner: MonoBehaviour<CreaturesPool, Player>
{
    [SerializeField] private CreatureDescription[] _creatureDescriptions;
    [SerializeField] private CreatureElement[] _creatureElements;
    
    private CreaturesPool _creaturesPool;
    private Player _player;

    protected override void Init(CreaturesPool firstArgument, Player secondArgument)
    {
        _creaturesPool = firstArgument;
        _player = secondArgument;
    }

    public void SpawnRandomCreature()
    {
        _creaturesPool.Pool.Get(out var creature);
        
        creature.SetupCreature(GetRandomCreatureDescription(), GetRandomCreatureElement(), 1, 1, 1);
        
        _player.Inventory.AddItem(creature);
    }
    
    private CreatureDescription GetRandomCreatureDescription()
    {
        int randomIndex = Random.Range(0, _creatureDescriptions.Length);
        
        if (_creatureDescriptions[randomIndex] == null) Debug.LogError("Описание существа не найдено!");

        return _creatureDescriptions[randomIndex];
    }

    private CreatureElement GetRandomCreatureElement()
    {
        int randomIndex = Random.Range(0, _creatureElements.Length);
        
        return _creatureElements[randomIndex];
    }
}
