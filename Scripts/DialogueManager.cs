using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour {
    
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;

    public AudioClip[] clips;


    private Queue<string> sentences;
    private Dialogue thisDialogue;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start() {
        sentences = new Queue<string>();
        audioSource = GetComponent<AudioSource>();
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
            if (letter != ' ') {
                playVoiceSound();
            }
            dialogueText.text += letter;
            for (int i = 0; i <= 25; i++) {
                yield return null;
            }
            
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

    public void playVoiceSound() {
        int randomNum = 0;
        if (string.Equals(nameText.text, "Courier")) {
           randomNum = Random.Range(0, 2);
        }
        else if (string.Equals(nameText.text, "Ghost")) {
           randomNum = Random.Range(3, 5);
        }
        
        audioSource.clip = clips[randomNum];
        audioSource.Play();
    }

}
