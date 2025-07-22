using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOneScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
