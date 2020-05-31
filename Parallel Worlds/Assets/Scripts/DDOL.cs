using UnityEngine;

namespace ParallelWorlds
{
    public class DDOL : MonoBehaviour
    {
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
