using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
        int delay = 0;
        foreach (char letter in sentence.ToCharArray()) {
            if (letter != ' ' && delay <= 0) {
                if (string.Equals(nameText.text, "You")) {
                    delay = 5;
                } else {
                    delay = 8;
                }
                playVoiceSound();
            }
            dialogueText.text += letter;
            for (int i = 0; i <= 5; i++) {
                yield return null;
            }

            delay--;
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
        SceneManager.LoadScene(2);
    }

    public void playVoiceSound() {
        int randomNum = 0;
        if (string.Equals(nameText.text, "Courier")) {
           randomNum = Random.Range(0, 3);
        }
        else if (string.Equals(nameText.text, "Ghost")) {
           randomNum = Random.Range(3, 6);
        }
         else if (string.Equals(nameText.text, "Vox2")) {
           randomNum = Random.Range(6, 9);
        }

        audioSource.clip = clips[randomNum];
        audioSource.Play();
    }

}
