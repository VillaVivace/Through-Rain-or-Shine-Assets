using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;


    private Queue<string> sentences;
    private Dialogue thisDialogue;

    // Start is called before the first frame update
    void Start() {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue) {
        thisDialogue = dialogue;
        animator.SetBool("isOpen", true);

        nameText.text = thisDialogue.playerName;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void ChangeName() {
        if (string.Equals(nameText.text, thisDialogue.playerName)) {
            nameText.text = thisDialogue.NPCName;
        } 
        else if (string.Equals(nameText.text, thisDialogue.NPCName)) {
            nameText.text = thisDialogue.playerName;
        }
    }

    void EndDialogue() {
        Debug.Log("End of conversation.");
        animator.SetBool("isOpen", false);
    }
}
