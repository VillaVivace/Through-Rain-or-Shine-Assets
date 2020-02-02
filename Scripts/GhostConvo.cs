using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostConvo : MonoBehaviour
{
    public DialogueTrigger dt;

    void Start() {
        dt = GetComponent<DialogueTrigger>();
    }
    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other);
        dt.TriggerDialogue();
    }
}
