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
    [SerializeField] private int sceneID = 1;
    [SerializeField] private int requireBananas = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            Destroy(collision.gameObject);
            collectSoundEffect.Play();
            bananas++;
            BananasText.text = "Bananas: " + bananas;
        }
        if (collision.gameObject.CompareTag("Trophy"))
        {
            trophyCollected = true;
            Destroy(collision.gameObject);
            Debug.Log("trophy collected");
            if (bananas >= requireBananas)
            {
                SceneManager.LoadScene(sceneID);
            }
        }
        
    }
}
