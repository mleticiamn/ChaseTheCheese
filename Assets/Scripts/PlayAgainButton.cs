using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayAgainButton : MonoBehaviour
{
    public void PlayAgain()
    {
        //MusicController.Instance.PlayMainMusic();
        SceneManager.LoadSceneAsync(1);
    }
}
