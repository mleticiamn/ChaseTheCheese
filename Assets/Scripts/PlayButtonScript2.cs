using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayButtonScript2 : MonoBehaviour
{
    public void PlayGame()
    {
        MusicController.Instance.PlayMainMusic();
        SceneManager.LoadSceneAsync(0);
    }
}
