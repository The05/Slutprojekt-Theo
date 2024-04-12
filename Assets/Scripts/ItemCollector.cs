using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int bananas = 0;
    private bool trophyCollected = false;
    [SerializeField] private TextMeshProUGUI BananasText;
    [SerializeField] private AudioSource collectSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trophy"))
        {
            trophyCollected = true;
            Destroy(collision.gameObject);
            Debug.Log("trophy collected");
        }
        if (collision.gameObject.CompareTag("Banana"))
        {
            Destroy(collision.gameObject);
            collectSoundEffect.Play();
            bananas++;
            BananasText.text = "Bananas: " + bananas;

            if (bananas == 13 && trophyCollected)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
