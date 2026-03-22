using ProjectGame.Buttons;
using ProjectGame.Combinations;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjectGame.UI
{
    public class CombineButton: MenuButtonLeftClickBase
    {
        [SerializeField] private Combiner _combiner;
        
        protected override void FireEvent()
        {
            _combiner.TryCombineCreatures();
        }
    }
}
