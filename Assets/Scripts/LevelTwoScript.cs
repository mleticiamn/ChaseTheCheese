using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTwoScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(3);
    }
}

