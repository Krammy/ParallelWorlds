using UnityEngine;

namespace ParallelWorlds
{
    public class AmbienceLoader : MonoBehaviour
    {
        [SerializeField] private GameObject ambienceObject;
        private static AmbienceLoader ambienceLoader = null;

        private void OnEnable()
        {
            if (ambienceLoader != null)
            {
                Destroy(gameObject);
                return;
            }
            ambienceLoader = this;
            DontDestroyOnLoad(gameObject);
            Instantiate(ambienceObject, transform);
        }
    }
}
