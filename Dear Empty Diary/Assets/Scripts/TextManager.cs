﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    #region TextManager Description
    /*
     * The Text Manager will handle outputting Text to the dialogue box area. 
     * To use: 
     *      1. Ensure you have an instance of TextManager in the scene.
     *      2. Add a TextScript to any triggerable object or event to trigger text. Check the 'PlayText' if you wish to play text for that object.
     *      3. The TextScript will communicate with the TextManager and pass the assigned text.
     *      4. After communicating, it will output the text you wrote in the TextScript's field to the dialogue box.
     *      5. Finally, button presses will progress with the dialogue in-order of the array.
    */
    #endregion

    #region Variables
    [SerializeField]
    private GameObject textBox; // The dialogue box panel (called 'Text Box')
    [SerializeField]
    private GameObject dialogueBox; // The text box attached to the panel (called 'Dialogue')
    private Text dialogueText; // The text associated to the dialogue box
    private string[] text; // The text passed to the TextManager to use
    private int textLength; // The number of entries in the text[] array
    private int counter = 0; // By default, start at entry 0 in the text array
    #endregion

    #region TextManager Functions
    void Start()
    {
        // Fetches the dialogue box's text component
        this.dialogueText = dialogueBox.GetComponent<Text>();
        ToggleTextBox();
    }

    // Function that takes in text and outputs it to the dialogue box
    public void WriteText(string[] script)
    {
        // Set the counter back to 0, text's max length, the text array, and print out the first entry
        this.counter = 0;
        // If we haven't enabled the dialogue box before, we enable it now
        if (!this.textBox.activeSelf)
        {
            ToggleTextBox();
            // NOTE: This makes it so that text can be overwritten by another incoming text.
        }
        this.textLength = script.Length - 1; // -1 because of array uses (i.e. an array of 2 elements returns length of 2, but we use element 0 and 1)
        this.text = script;
        this.dialogueText.text = this.text[this.counter];
    }

    // Toggles the text box (on if off, off if on)
    public void ToggleTextBox()
    {
        this.textBox.SetActive(!this.textBox.activeSelf);
        // this.dialogueBox.SetActive(!this.dialogueBox.activeSelf);
    }

    // Progresses automatically to the next dialogue in the array (if it exists)
    public void ProgressThroughDialogueAutomatically()
    {
        // If there is still some text to output after pressing OK
        if (counter < textLength)
        {
            // Increment our counter, and then print out the text
            this.counter++;
            this.dialogueText.text = this.text[this.counter];
        }
        else
        {
            // Otherwise, toggle the text box on pressing OK
            ToggleTextBox();
        }
    }
    #endregion

}