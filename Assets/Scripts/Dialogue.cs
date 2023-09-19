using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public GameObject textBox;
    private int index;

    void Start()
    {
        textComponent.text = string.Empty;
        textBox.SetActive(false); // Ensure the textbox is initially inactive
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC") && other.gameObject.name == "NPC1")
        {
            Debug.Log("Player connected with NPC1"); // Debug statement (optional)
            textBox.SetActive(true); // Activate the textbox
            StartDialogue(); // Start the dialogue when the trigger is entered
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            Debug.Log("Dialogue completed"); // Debug statement (optional)
            gameObject.SetActive(false);
        }
    }
}
