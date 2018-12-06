using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;

    [SerializeField]
    private GameObject wizard;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            TriggerDialogue();
        }

        if(gameObject.name == "DialogueEvent1")
        {
            wizard.SetActive(true);
            wizard.GetComponent<Animator>().SetBool("IsFadingIn", true);
            wizard.GetComponent<Animator>().SetBool("IsFadingOut", false);
            wizard.transform.position = new Vector3(-1.57f, 2.44f, 0.0f);
        }

        if (gameObject.name == "DialogueEvent2")
        {
            wizard.GetComponent<Animator>().SetBool("IsFadingIn", true);
            wizard.GetComponent<Animator>().SetBool("IsFadingOut", false);
            wizard.transform.position = new Vector3(-9.4f, -1.5f, 0.0f);
        }

        if (gameObject.name == "DialogueEvent3")
        {
            wizard.GetComponent<Animator>().SetBool("IsFadingIn", true);
            wizard.GetComponent<Animator>().SetBool("IsFadingOut", false);
            wizard.transform.position = new Vector3(-9.5f, 3.5f, 0.0f);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
