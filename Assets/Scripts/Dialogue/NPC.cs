using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    private DialogueSystem dialogueSystem;

    public static string npcName = "Dialogue Man"; //Input for the npc name
    [TextArea(5, 10)]
    public string[] sentences;

    void Start()
    {
        dialogueSystem = FindObjectOfType<DialogueSystem>();   
    }

    public void OnTriggerStay(Collider col)
    {
        gameObject.GetComponent<NPC>().enabled = true;
        FindObjectOfType<DialogueSystem>().EnterRangeOfNPC();
        if (col.gameObject.tag == "Player")
        {
            gameObject.GetComponent<NPC>().enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {                
                dialogueSystem.dialogueLines = sentences; //the sentences are sent to the dialogueSystem
                FindObjectOfType<DialogueSystem>().NPCName(); 
            }            
        }
    }

    public void OnTriggerExit(Collider col)
    {
        FindObjectOfType<DialogueSystem>().OutOfRange();
        gameObject.GetComponent<NPC>().enabled = false;
    }
}
