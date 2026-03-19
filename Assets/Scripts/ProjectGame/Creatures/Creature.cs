using UnityEngine;
using UnityEngine.Rendering;

public class Creature: MonoBehaviour
{
    private string _id; // Уникальный ID для сохранения
    private CreatureType _type;       // Например: Dragon, Golem
    private CreatureElement _element; // Например: Fire, Water
    
    // Характеристики (берутся средние при скрещивании)
    private readonly ValueComponent _size = new ValueComponent();
    private readonly ValueComponent _intelligence = new ValueComponent();
    private readonly ValueComponent _aggression = new ValueComponent();

    private bool _isBroken; // Флаг "сломанного существа"

    public Creature(CreatureType t, CreatureElement e, int s, int i, int a)
    {
        _type = t;
        _element = e;
        _size.SetMin(1);
        _size.SetMax(10);
        _size.Set(s);
        _intelligence.SetMin(0);
        _intelligence.SetMax(10);
        _intelligence.Set(i);
        _aggression.SetMin(0);
        _aggression.SetMax(10);
        _aggression.Set(i);
        _isBroken = false;
        _id = System.Guid.NewGuid().ToString();
    }
}
