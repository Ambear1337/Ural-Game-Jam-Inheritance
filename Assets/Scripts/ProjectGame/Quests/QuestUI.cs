using UnityEngine;

namespace ProjectGame.Quests
{
    public class QuestUI: MonoBehaviour
    {
        private Quest _quest;

        public void SetupQuest(Quest quest)
        {
            _quest = quest;
        }
    }
}