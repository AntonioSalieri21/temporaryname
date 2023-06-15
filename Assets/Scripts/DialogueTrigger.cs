using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    //public Dialogue dialogue;
    public Dialogue[] dialogues;
    public bool playOnce = true;
    private bool wasPlayed = false;
    public void TriggerDialogue()
    {
        if(playOnce)
        {
            if(!wasPlayed) FindObjectOfType<DialogueManager>().StartDialogue(dialogues[0]);
            wasPlayed = true;
        }
        else
            FindObjectOfType<DialogueManager>().StartDialogue(dialogues[0]);
        
    }

    



}
