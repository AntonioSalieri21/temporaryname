using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    [Header("UI")] 
    
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Image image;
    private Queue<string> sentences;

    public Animator animator;
    Dialogue[] innerDialogues;
    private int dialogueIndex = 0;

    public void StartDialogue(Dialogue[] dialogues)
    {

        animator.SetBool("Active", true);
        sentences = new Queue<string>();
        sentences.Clear();
        innerDialogues = dialogues;
        ContinueDialogue();

    }

    private void ContinueDialogue()
    {
        Debug.Log("DialogueIndex = " + dialogueIndex + "   innerDialogues.Length = " + (innerDialogues.Length-1));
        if(dialogueIndex > innerDialogues.Length-1) {EndDialogue(); return;}
        
        Dialogue dialogue = innerDialogues[dialogueIndex];
        

        nameText.text = dialogue.person.p_name;
        image.sprite = dialogue.person.p_image;       
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }


    public void DisplayNextSentence()
    {
        if(sentences.Count == 0){dialogueIndex++; ContinueDialogue(); return;}

        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }
    
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }

    }

    public void EndDialogue()
    {
        animator.SetBool("Active", false);
        dialogueText.text = "";
        nameText.text = "";
        dialogueIndex = 0;
    }
}
