using UnityEngine;
using TMPro;

public class CheeseManager : MonoBehaviour
{
    public static CheeseManager Instance;

    public AudioClip collectSound;
    public TextMeshPro cheeseCounterText;

    private int cheeseCount = 0;
    private AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        UpdateCounter();
    }

    public void CollectCheese()
    {
        cheeseCount++;
        audioSource.PlayOneShot(collectSound);
        UpdateCounter();
    }

    void UpdateCounter()
    {
        cheeseCounterText.text = $"Queijos: {cheeseCount}/3";
    }
}