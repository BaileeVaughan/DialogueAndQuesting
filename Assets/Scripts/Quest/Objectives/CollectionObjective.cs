using System.Collections;
using UnityEngine;

namespace QuestSystem
{
    public class CollectionObjective : IQuestObjective
    {
        private string title;
        private string description;
        private int collectionAmount;
        private int curAmount = 0;
        private bool isComplete;
        private GameObject itemToCollect;
        
        public CollectionObjective(GameObject item, int totalAmount, string descrip)
        {
            itemToCollect = item;
            description = descrip;
            collectionAmount = totalAmount;
            title = "Go grab the " + item.name;
            isComplete = false;
        }

        public string Title
        {
            get
            {
                return title;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
        }
        public int CollectionAmount
        {
            get
            {
                return collectionAmount;
            }
        }
        public int CurAmount
        {
            get
            {
                return curAmount;
            }
        }
        public GameObject ItemToCollect
        {
            get
            {
                return itemToCollect;
            }
        }

        public bool IsComplete
        {
            get
            {
                return isComplete;
            }
        }

        public void CheckProgress()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateProgress()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return "";
        }
    }
}
