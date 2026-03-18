using UnityEngine;

public class Creature
{
    private CreatureType _creatureType;
    private CreatureElement _creatureElement;
    private ValueComponent _size;
    private ValueComponent _intelligence;
    private ValueComponent _agression;

    private void Initialize(CreatureType creatureType, CreatureElement creatureElement)
    {
        _creatureType = creatureType;
        _creatureElement = creatureElement;
    }
}
