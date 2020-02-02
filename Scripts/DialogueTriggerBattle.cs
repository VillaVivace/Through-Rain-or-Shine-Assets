using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerBattle : MonoBehaviour
{
    public DialogueBattle dialogue;


    public void TriggerDialogue () {
        
        FindObjectOfType<DialogueManagerBattle>().StartDialogue(dialogue);


    }
}
