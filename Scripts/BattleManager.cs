using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleManager : MonoBehaviour
{

    public Button goodChoice;
    public Button neutralChoice;
    public Button badChoice;

    public TextMeshProUGUI goodText;
    public TextMeshProUGUI neutralText;
    public TextMeshProUGUI badText;

    public Slider slider;

    public TextMeshProUGUI dialog;

    public float acceptanceAmt = 0.50f;

    public string[] grieving1;
    public string[] grieving2;
    public string[] grieving3;
    public string[] grieving4;
    public string[] grieving5;
    public string[] acceptance1;
    public string[] acceptance2;
    public string[] acceptance3;
    public string[] acceptance4;
    public string[] acceptance5;

    public string[] referenceArray;

    private AudioSource audio;

    public Animator enemyAnim;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        goodText = goodChoice.GetComponentInChildren<TextMeshProUGUI>();
        neutralText = neutralChoice.GetComponentInChildren<TextMeshProUGUI>();
        badText = badChoice.GetComponentInChildren<TextMeshProUGUI>();
        referenceArray = grieving1;
        dialog.text = referenceArray[0];
        goodText.text = referenceArray[1];
        neutralText.text = referenceArray[2];
        badText.text = referenceArray[3];
    }

    // Update is called once per frame
    void changeText() {
        if (slider.value <= 0.50f) {
            if (referenceArray == grieving1) {
                referenceArray = grieving2;
            }
            else if (referenceArray == grieving2) {
                referenceArray = grieving3;
            }
            else if (referenceArray == grieving3) {
                referenceArray = grieving4;
            }
            else if (referenceArray == grieving4) {
                referenceArray = grieving5;
            }
            else if (referenceArray == grieving5 || referenceArray == acceptance1 || referenceArray == acceptance2 || referenceArray == acceptance3 || referenceArray == acceptance4 || referenceArray == acceptance5) {
                referenceArray = grieving1;
            }
        }
        else if (slider.value > 0.50f) {
            if (referenceArray == acceptance1) {
                referenceArray = acceptance2;
            }
            else if (referenceArray == acceptance2) {
                referenceArray = acceptance3;
            }
            else if (referenceArray == acceptance3) {
                referenceArray = acceptance4;
            }
            else if (referenceArray == acceptance4) {
                referenceArray = acceptance5;
            }
            else if (referenceArray == acceptance5 || referenceArray == grieving1 || referenceArray == grieving2 || referenceArray == grieving3 || referenceArray == grieving4 || referenceArray == grieving5) {
                referenceArray = acceptance1;
            }
        }
        
        dialog.text = referenceArray[0];
        goodText.text = referenceArray[1];
        neutralText.text = referenceArray[2];
        badText.text = referenceArray[3];
        audio.Play();
        enemyAnim.SetTrigger("hitGhost");
        
    }

    public void makeGoodChoice() {
        slider.value += 0.167f;
        changeText();
    }

    public void makeNeutralChoice() {
        slider.value += 0f;
        changeText();
    }

    public void makeBadChoice() {
        slider.value -= 0.167f;
        changeText();
    } 
}
