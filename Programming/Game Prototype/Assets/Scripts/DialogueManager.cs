﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    public GameObject dialogueBox;

    private Queue<string> sentences;

    public bool dialogFreezePlayer = false;

	// Use this for initialization
	void Start ()
    {
        sentences = new Queue<string>();
	}

    public void StartDialogue(Dialogue dialogue)
    {
        dialogFreezePlayer = true;

        dialogueBox.SetActive(true);

        animator.SetBool("IsOpen", true);

        Debug.Log("Starting tutorial conversation...");

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        //stop chars animating if new dialog is triggered
        //StopAllCoroutines();

        //StartCoroutine(TypeSentence(sentence));

        dialogueText.text = sentence;
        Debug.Log(sentence);
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = null;
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        dialogFreezePlayer = false;

        animator.SetBool("IsOpen", false);

        Debug.Log("End of Conversation");
    }
}
