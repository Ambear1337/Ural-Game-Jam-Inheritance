using ProjectGame;
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

    public void SetupCreature(CreatureDescription creatureDescription, CreatureElement element, int s, int i, int a)
    {
        _creatureDescription = creatureDescription;

        if (!_creatureDescription) return;

        _type = _creatureDescription.CreatureType;
        _element = element;
        _size.SetMin(0);
        _size.SetMax(10);
        _size.Set(s);
        _intelligence.SetMin(0);
        _intelligence.SetMax(10);
        _intelligence.Set(i);
        _aggression.SetMin(0);
        _aggression.SetMax(10);
        _aggression.Set(a);
    }
}
