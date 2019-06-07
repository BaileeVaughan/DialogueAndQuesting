//I followed this tutorial:
//https://www.youtube.com/watch?v=p4a_OYmk1uU&t=6s
//but it still doesn't work
//I did make some changes to better suit this simple project,
//but I don't think it'd be too drastic as to stop the script from working

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Transform dialoguePrompt; //these refer to the "E to talk"
    public Transform dialogueGUI; //and the dialogue box

    public Text nameText; //the npc name text
    public Text dialogueText; //and dialogue text

    public float letterDelay = 0.1f; //the speed of each letter
    public float letterMultiplier = 0.5f; //and the amount it is multiplied by when you hold the input down

    public string[] dialogueLines; //the dialogue content

    public KeyCode dialogueInput = KeyCode.E; //interaction button

    public bool letterIsMultiplied = false; //if the interact button is being held down
    public bool dialogueActive = false; //if the text box is active
    public bool dialogueEnded = false; //if there are no more sentences
    public bool outOfRange = true; //if the player is within range of the npcs trigger sphere

    void Start()
    {
        dialogueText.text = "";
    }

    public void EnterRangeOfNPC()
    {
        outOfRange = false;
        dialoguePrompt.gameObject.SetActive(true); //activates the prompt 
        if (dialogueActive == true)
        {
            dialoguePrompt.gameObject.SetActive(false); //disables the prompt if the text box is showing
        }
    }

    public void NPCName()
    {
        outOfRange = false;
        dialogueGUI.gameObject.SetActive(true); //text box is active
        if (Input.GetKeyDown(dialogueInput))
        {
            if (!dialogueActive)
            {
                dialogueActive = true;
                StartCoroutine(StartDialogue());
            }
        }
        StartDialogue();
    }

    private IEnumerator StartDialogue()
    {
        if (outOfRange == false)
        {
            int dialogueLength = dialogueLines.Length;
            int currentDialogueIndex = 0;
            while (currentDialogueIndex < dialogueLength || !letterIsMultiplied)
            {
                if (!letterIsMultiplied)
                {
                    letterIsMultiplied = true;
                    StartCoroutine(DisplayString(dialogueLines[currentDialogueIndex++]));
                    if (currentDialogueIndex >= dialogueLength)
                    {
                        dialogueEnded = true;
                    }
                }
                yield return 0;
            }
            while (true)
            {
                if (Input.GetKeyDown(dialogueInput) && dialogueEnded == false)
                {
                    break;
                }
                yield return 0;
            }
            dialogueEnded = false;
            dialogueActive = false;
            DropDialogue();
        }
    }

    private IEnumerator DisplayString(string stringToDisplay)
    {
        if (outOfRange == false)
        {
            int stringLength = stringToDisplay.Length;
            int currentCharacterIndex = 0;

            dialogueText.text = "";

            while (currentCharacterIndex < stringLength)
            {
                dialogueText.text += stringToDisplay[currentCharacterIndex];
                currentCharacterIndex++;

                if (currentCharacterIndex < stringLength)
                {
                    if (Input.GetKey(dialogueInput))
                    {
                        yield return new WaitForSeconds(letterDelay * letterMultiplier); //multiplying the letter speed
                    }
                    else
                    {
                        yield return new WaitForSeconds(letterDelay); //else, the letter speed is normal
                    }
                }
                else
                {
                    dialogueEnded = false;
                    break;
                }
            }
            while (true)
            {
                if (Input.GetKeyDown(dialogueInput))
                {
                    break;
                }
                yield return 0;
            }
            dialogueEnded = false;
            letterIsMultiplied = false;
            dialogueText.text = "";
        }
    }

    public void DropDialogue()
    {
        dialoguePrompt.gameObject.SetActive(true);
        dialogueGUI.gameObject.SetActive(false);
    }

    public void OutOfRange()
    {
        outOfRange = true; //player is now out of range
        if (outOfRange == true)
        {
            StopAllCoroutines(); //stops all the coroutines and
            letterIsMultiplied = false; //sets all other bools to false
            dialogueActive = false;
            dialoguePrompt.gameObject.SetActive(false);
            dialogueGUI.gameObject.SetActive(false);
        }
    }
}