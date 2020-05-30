using UnityEngine;
using UnityEngine.SceneManagement;

namespace ParallelWorlds
{
    public class NextSceneSwitcher : MonoBehaviour
    {
        public void SwitchScene()
        {
            int nextLevel = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
            SceneManager.LoadScene(nextLevel);
        }
    }
}