using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogues : MonoBehaviour {

    [Tooltip("Defines which panel being used.")]
    public GameObject textBox;

    [Tooltip("Defines which text being used.")]
    public Text theText;

    private TextAsset textFile;

    [Tooltip("Defines all the dialogue lines in the text file.")]
    public string[] textLines;

    [Tooltip("Defines which line in the text file will be displayed.")]
    public int currentLine;

    [Tooltip("Defines which line in the text file will be the last message displayed.")]
    public int endAtLine;

    private int timer;
    private RubyWalk ruby;
    private bool isActive;

    // Use this for initialization
    void Start()
    {
        ruby = FindObjectOfType<RubyWalk>();

        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if(endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

        if(isActive)
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(!isActive)
        {
            return;
        }

        theText.text = textLines[currentLine];

        timer++;
        if (timer == 100)
        {
            currentLine += 1;
            timer = 0;
        }

        if(currentLine > endAtLine)
        {
            DisableTextBox();
        }
    }

    // EnableTextBox displays the textbox
    public void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;
    }

    // DisableTextBox hides the textbox
    public void DisableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;
    }

    // ReloadScript takes a new text and loads it
    public void ReloadScript(TextAsset theText)
    {
        if (theText != null)
        {
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }
    }
}
