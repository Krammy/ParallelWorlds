using UnityEngine;
using UnityEngine.SceneManagement;

namespace ParallelWorlds
{
    public class SceneSwitcher : MonoBehaviour
    {
        [SerializeField] private int sceneBuildIndex = 0;

        public void SwitchScene()
        {
            SceneManager.LoadScene(sceneBuildIndex);
        }
    }
}