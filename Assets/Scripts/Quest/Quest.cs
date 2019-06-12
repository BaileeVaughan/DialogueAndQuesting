using System.Collections.Generic;

namespace QuestSystem
{
    public class Quest
    {
        private IQuestText info;
        public IQuestText Info
        {
            get { return info; }
        }

        private List<IQuestObjective> objectives;

    }
}
