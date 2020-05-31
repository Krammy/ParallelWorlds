using UnityEngine;
using UnityEngine.Events;

namespace ParallelWorlds
{
    public class EventToggle : MonoBehaviour
    {
        [SerializeField] private UnityEvent onToggleTrue = null;
        [SerializeField] private UnityEvent onToggleFalse = null;

        private bool toggle = false;

        public void Switch()
        {
            toggle = !toggle;
            if (toggle)
            {
                onToggleTrue.Invoke();
            }
            else
            {
                onToggleFalse.Invoke();
            }
        }
    }
}
