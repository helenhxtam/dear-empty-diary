using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour
{

    #region TextScript Description
    /*
     * The TextScript objected is attached to every interactable object that would trigger text (or door if you use it that way).
     * When an object is interacted with (or would trigger text, i.e. by colliding with it), simply call a function here that communicates with the TextManager.
     * It then processes writing the text.
    */
    #endregion

    #region Variables
    [Tooltip("The text we wish to print out.")]
    public string[] dialogueText; // The dialogue text we'll be sending over, line by line, to the TextManager.
    [SerializeField]
    private GameObject textManager; // The Text Manager object - if we don't assign it, automatically find it.
    [Tooltip("Boolean to determine whether or not, on collision/trigger, we output text.")]
    public bool playText;
    #endregion

    #region TextScript functions
    void Start()
    {
        // Verify that a TextManager was attached, else attach it (find it)
        if (!this.textManager)
        {
            this.textManager = GameObject.Find("TextManager");
        }
    }

    // On trigger OR collision, handle checking if we play text at all.
    void OnTriggerEnter2D(Collider2D col)
    {
        if (playText)
        {
            TriggerDialogue();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (playText)
        {
            TriggerDialogue();
        }
    }
    // -------------------------

    // Function to communicate with the TextManager by passing to it the dialogue text array.
    // Every other functionality is handled through the button in the canvas.
    public void TriggerDialogue()
    {
        textManager.GetComponent<TextManager>().WriteText(dialogueText);
    }
    #endregion
}
