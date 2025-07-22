using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    public static MusicController Instance;

    public AudioClip mainTheme;
    public AudioClip victoryTheme;
    public AudioClip defeatTheme;

    private AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = mainTheme;
            audioSource.loop = true;
            audioSource.Play();

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Desativa temporariamente o loop para músicas de vitória/derrota
        audioSource.loop = false;

        if (scene.name == "Won Screen")
        {
            PlayVictoryMusic();
        }
        else if (scene.name == "Lost Screen")
        {
            PlayDefeatMusic();
        }
        else // Para todas as outras cenas (menu, jogo, etc)
        {
            audioSource.loop = true;
            PlayMainMusic();
        }
    }

    public void PlayMainMusic()
    {
        if (audioSource.clip == mainTheme && audioSource.isPlaying) return;

        audioSource.loop = true;
        audioSource.Stop();
        audioSource.clip = mainTheme;
        audioSource.Play();
    }

    public void PlayVictoryMusic()
    {
        if (audioSource.clip == victoryTheme && audioSource.isPlaying) return;

        audioSource.loop = false;
        audioSource.Stop();
        audioSource.clip = victoryTheme;
        audioSource.Play();
    }

    public void PlayDefeatMusic()
    {
        if (audioSource.clip == defeatTheme && audioSource.isPlaying) return;

        audioSource.loop = false;
        audioSource.Stop();
        audioSource.clip = defeatTheme;
        audioSource.Play();
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}