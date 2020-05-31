using UnityEngine;
using UnityEngine.Events;

namespace ParallelWorlds
{
    public class EnableEvent : MonoBehaviour
    {
        [SerializeField] private UnityEvent onEnable = null;

        private void OnEnable()
        {
            onEnable.Invoke();
        }
    }
    
}
