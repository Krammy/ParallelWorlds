using UnityEngine;

namespace ParallelWorlds
{
    public class ToggleObject : MonoBehaviour
    {
        [SerializeField] private GameObject toggleObject = null;

        public void Toggle()
        {
            toggleObject.SetActive(!toggleObject.activeSelf);
        }
    }
}
