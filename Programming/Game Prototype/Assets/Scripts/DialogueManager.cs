﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    [SerializeField]
    private GameObject audioManager;
    private WwiseAudioManager wwiseAudioManager;

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    public GameObject dialogueBox;

    private Queue<string> sentences;

    public bool dialogFreezePlayer = false;

	// Use this for initialization
	void Start ()
    {
        wwiseAudioManager = audioManager.GetComponent<WwiseAudioManager>();

        sentences = new Queue<string>();
	}

    public void StartDialogue(Dialogue dialogue)
    {
        dialogFreezePlayer = true;

        wwiseAudioManager.DialogueInSound();

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
        StopAllCoroutines();


        StartCoroutine(TypeSentence(sentence));

        Debug.Log(sentence);
    }

    IEnumerator TypeSentence (string sentence)
    {
        //dialogueText.text = null;
        for(int i = 0; i < sentence.Length+1; i++)
        {
            dialogueText.text = sentence.Substring(0,i);
            yield return new WaitForSeconds(.03f);
        }
    }

    void EndDialogue()
    {
        dialogFreezePlayer = false;

        animator.SetBool("IsOpen", false);

        Debug.Log("End of Conversation");
    }
}
