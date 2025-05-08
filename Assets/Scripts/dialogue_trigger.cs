using System.Collections.Generic;
using UnityEngine;

// all of these things can be edited in the Inspector
// store info about the character speaking
[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
}

// store a character's line
[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;
}

// store a list of all dialogue lines
[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}

public class dialogue_trigger : MonoBehaviour
{
    public Dialogue dialogue;
    private bool hasTriggered = false;

    // player triggered a dialogue collider (see update_player.cs where this is called)
    public void TriggerDialogue()
    {
        // make sure the dialogue trigger has not yet been activated
        if (!hasTriggered)
        {
            hasTriggered = true;
            dialogue_manager.Instance.StartDialogue(dialogue);
        }
    }
}
