using ProjectGame;
using ProjectGame.Creatures;
using ProjectGame.UI.InventorySystem;
using UnityEngine;
using UnityEngine.Rendering;

public class Creature: Item
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

    public void SetupCreature(CreatureType type, CreatureElement element, int s, int i, int a)
    {
        if (!type || !element) return;

        _type = type;
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

        _itemSprite = type.CreatureTypeSprite;
    }
}
