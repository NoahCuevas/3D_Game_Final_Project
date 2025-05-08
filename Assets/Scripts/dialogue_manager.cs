using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

// shows/hides dialogue box + updates dialogue text and icons
public class dialogue_manager : MonoBehaviour
{
    public static dialogue_manager Instance;

    // assigned in Inspector
    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;

    private Queue<DialogueLine> lines;
    
    public bool isDialogueActive = false;

    public float typingSpeed = 0.04f;

    // used to show/hide the dialogue box
    public GameObject box;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        box.SetActive(false);
        lines = new Queue<DialogueLine>();
    }

    public bool IsDialogueActive()
    {
        return isDialogueActive;
    }


    public void StartDialogue(Dialogue dialogue)
    {
        isDialogueActive = true;
        box.SetActive(true);

        // Show and unlock the cursor when dialogue starts
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        lines.Clear();

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            // put lines into a queue (first in, first out)
            lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();
    }

    public void DisplayNextDialogueLine()
    {
        // no more lines left
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = lines.Dequeue();

        // display all info for current line
        characterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;

        StopAllCoroutines();

        // used for animating the dialogue
        StartCoroutine(TypeSentence(currentLine));
    }

    public void SkipDialogue()
    {
        if (!isDialogueActive) return;
        
        StopAllCoroutines();
        lines.Clear();
        EndDialogue();
    }

    // animate dialogue to appear as if it's being typed
    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    // hide dialogue box
    void EndDialogue()
    {
        isDialogueActive = false;
        box.SetActive(false);

        // Hide and lock the cursor when dialogue ends
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
