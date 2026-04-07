using System.Collections.Generic;
using ProjectGame.Creatures;
using UnityEngine;

namespace ProjectGame.Quests
{
    public class Quest: ScriptableObject
    {
        [SerializeField] private string _questName;
        [SerializeField] private string _questDescription;
        [SerializeField] private List<CreatureType> _neededCreatureTypes;
        [SerializeField] private List<CreatureElement> _neededCreatureElements;
        [SerializeField] private int _rewardValue;
    }
}
