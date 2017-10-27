using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogues : MonoBehaviour {

    public GameObject textBox;

    public Text theText;

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public RubyWalk ruby;

    public bool isActive;

    public bool stopMovement;

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

        if (Input.GetKeyDown(KeyCode.Return))
        {
            currentLine += 1;
        }

        if(currentLine > endAtLine)
        {
            DisableTextBox();
        }
    }

    public void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;
        stopMovement = true;

        if(stopMovement)
        {
            ruby.isMoving = false;
        }
    }

    public void DisableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;

        ruby.isMoving = true;
    }

    public void ReloadScript(TextAsset theText)
    {
        if (theText != null)
        {
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }
    }
}
