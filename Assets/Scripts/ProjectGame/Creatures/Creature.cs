using ProjectGame;
using ProjectGame.Creatures;
using UnityEngine;
using UnityEngine.Rendering;

public class Creature: MonoBehaviour
{
    private CreatureType _type;
    public CreatureType Type => _type;
    
    private CreatureElement _element;
    public CreatureElement Element => _element;

    [SerializeField]
    private ValueComponent _size;
    public ValueComponent Size => _size;
    [SerializeField]
    private ValueComponent _intelligence;
    public ValueComponent Intelligence => _intelligence;
    [SerializeField]
    private ValueComponent _aggression;
    public ValueComponent Aggression => _aggression;
    private CreatureDescription _creatureDescription;
    public CreatureDescription CreatureDescription => _creatureDescription;
    private CreatureElementDescription _elementDescription;
    public CreatureElementDescription ElementDescription => _elementDescription;

    private int _cost = 10;
    public int Cost => _cost;

    public void SetupCreature(CreatureDescription creatureDescription, CreatureElementDescription elementDescription, int s, int i, int a, int cost)
    {
        _creatureDescription = creatureDescription;
        _elementDescription = elementDescription;

        if (!_creatureDescription || !_elementDescription) return;

        _type = _creatureDescription.CreatureType;
        _element = _elementDescription.CreatureElement;
        _size.SetMin(0);
        _size.SetMax(10);
        _size.Set(s);
        _intelligence.SetMin(0);
        _intelligence.SetMax(10);
        _intelligence.Set(i);
        _aggression.SetMin(0);
        _aggression.SetMax(10);
        _aggression.Set(a);

        _cost = cost;
    }
}
