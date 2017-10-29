using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour
{

    [Tooltip("Defines which text file is being read.")]
    public TextAsset theText;

    [Tooltip("Defines which line in the text file will be displayed first.")]
    public int startLine;

    [Tooltip("Defines which line in the text file will be the last message displayed.")]
    public int endLine;

    [Tooltip("Defines if a dialogue has triggered and destroys the object that was triggered.")]
    public bool destroyWhenActivated;

    private Dialogues theTextBox;

    //public bool requiredButtonPress;
    //private bool waitForPress;

    // Use this for initialization
    void Start()
    {
        theTextBox = FindObjectOfType<Dialogues>();
    }

    // Update is called once per frame
    void Update()
    {
        // Placeholder interaction (melee I guess) with an object to activate dialogue
        /*if(waitForPress && Input.GetKeyDown(KeyCode.J))
        {
            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableTextBox();

            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }*/
    }

    // Upon entering trigger, load a text file and pop up a textbox to display the dialogues
    void OnTriggerEnter2D(Collider2D col)
    {
        theTextBox.ReloadScript(theText);
        theTextBox.currentLine = startLine;
        theTextBox.endAtLine = endLine;
        theTextBox.EnableTextBox();

        if (destroyWhenActivated)
        {
            Destroy(gameObject);
        }
        /*if(col.name == "Ruby")
        {
            if(requiredButtonPress)
            {
                waitForPress = true;
                return;
            }
        }*/
    }

    /*void OnTriggerExit2D(Collider2D col)
    {
        if(col.name == "Ruby")
        {
            waitForPress = false;
        }
    }*/
}
