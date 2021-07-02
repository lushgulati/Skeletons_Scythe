using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    public Animator animator2;
    public Animator player;
    public ParticleSystem heal;
    static int count = 0;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
        animator2.SetBool("IsTriggered", false);
    }
    public void StartDialogue(Dialogue dialogue)
    {
        PlayerMovement.canMove = false;

        animator.SetBool("IsOpen", true);

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
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        PlayerMovement.canMove = true;
        animator.SetBool("IsOpen", false);
        if(nameText.text == "Merchant" && count == 0)
        {
            animator.SetTrigger("heal");
            heal.Play();
            StartCoroutine(UseSouls());
            FindObjectOfType<PlayerCombat>().metMerchant();
            FindObjectOfType<HealthBar>().merchantUpdate();
            FindObjectOfType<SoulCounter>().merchantSouls();
            count++;
        }
    }
    IEnumerator UseSouls()
    {
        PlayerMovement.canMove = false;
        FindObjectOfType<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(1);
        FindObjectOfType<PlayerMovement>().enabled = true;
        PlayerMovement.canMove = true;
    }
}
