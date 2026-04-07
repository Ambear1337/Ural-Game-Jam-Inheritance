using UnityEngine;

public class CreatureType: ScriptableObject
{
    [SerializeField] 
    private string _creatureTypeName;
    public string CreatureTypeName => _creatureTypeName;
    [SerializeField]
    private Sprite _creatureTypeSprite;
    public Sprite CreatureTypeSprite => _creatureTypeSprite;
    [SerializeField] 
    private int _cost;
}
