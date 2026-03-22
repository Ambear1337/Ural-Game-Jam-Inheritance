namespace ProjectGame.UI
{
    [System.Serializable]
    public class CreatureSlot
    {
        private Creature _creature;
        public Creature Creature => _creature;

        public bool IsEmpty => _creature == null;

        public void Clear()
        {
            _creature = null;
        }

        public void Set(Creature newCreature)
        {
            _creature = newCreature;
        }

        public void Add(Creature newCreature)
        {
            if (_creature == null)
            {
                Set(newCreature);
            }
        }
    }
}