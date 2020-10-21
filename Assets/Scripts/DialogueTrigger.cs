using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public void TriggerDialgoue()
    {
        FindObjectOfType<dialogueManager>().StartDialogue(dialogue);
    }
}
