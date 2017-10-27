using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour {

    public TextAsset theText;

    public int startLine;
    public int endLine;

    public Dialogues theTextBox;

    //public bool requiredButtonPress;
    //private bool waitForPress;

    public bool destroyWhenActivated;

	// Use this for initialization
	void Start () {
        theTextBox = FindObjectOfType<Dialogues>();
	}
	
	// Update is called once per frame
	void Update () {

  //      // Placeholder interaction (melee I guess) with an object to activate dialogue
		//if(waitForPress && Input.GetKeyDown(KeyCode.J))
  //      {
  //          theTextBox.ReloadScript(theText);
  //          theTextBox.currentLine = startLine;
  //          theTextBox.endAtLine = endLine;
  //          theTextBox.EnableTextBox();

  //          if (destroyWhenActivated)
  //          {
  //              Destroy(gameObject);
  //          }
  //      }
	}

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
        //if(col.name == "Ruby")
        //{
        //    if(requiredButtonPress)
        //    {
        //        waitForPress = true;
        //        return;
        //    }
        //}
    }

    //void OnTriggerExit2D(Collider2D col)
    //{
    //    if(col.name == "Ruby")
    //    {
    //        waitForPress = false;
    //    }
    //}
}
