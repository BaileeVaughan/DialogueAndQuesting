namespace QuestSystem
{
    public class QuestInfo : IQuestText
    {
        private string title;
        private string descriptionSummary;
        private string dialogue;
        private string hint;

        public string Title
        {
            get
            {
                return title;
            }
        }

        public string DescriptionSummary
        {
            get
            {
                return descriptionSummary;
            }
        }

        public string Hint
        {
            get
            {
                return hint;
            }
        }

        public string Dialogue
        {
            get
            {
                return dialogue;
            }
        }
    }
}

