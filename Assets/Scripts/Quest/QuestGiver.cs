using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public PlayerManager player;

    public GameObject questWindow;
    public Text titleText;
    public Text descripText;
    public Text rewardText;
    public int click;

    private void Update()
    {
        quest.clicks = click;
        if (quest.clicks >= 10)
        {
            questWindow.SetActive(false);
            player.goldAmount = 999;
        }
    }

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        quest.isActive = true;
        titleText.text = quest.title;
        descripText.text = quest.descrip;
        rewardText.text = "Reward: " + quest.reward.ToString() + " gold";
    }

    public void Click()
    {
        click++;
    }

    public void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            OpenQuestWindow();
        }
    }
}
