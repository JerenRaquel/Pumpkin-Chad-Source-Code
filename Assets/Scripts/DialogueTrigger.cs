using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public bool enableDialogueOnStart = false;

    [Header("Settings for cutscene enabled")]
    public bool cutsceneType;
    public int sceneTransitionNumber;

    [Header("Dialogue")]
    public Dialogue dialogue;

    void Start()
    {
        if(enableDialogueOnStart)
        {
            TriggerDialogue();
        }
    }
    
    public void TriggerDialogue()
    {
        dialogueManager.StartDialogue(dialogue, cutsceneType, sceneTransitionNumber);
    }
}
