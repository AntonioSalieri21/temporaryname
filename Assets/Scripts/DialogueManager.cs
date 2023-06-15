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

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("Active", true);
        sentences.Clear();
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
        if(sentences.Count == 0){EndDialogue(); return;}

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
    }
}
