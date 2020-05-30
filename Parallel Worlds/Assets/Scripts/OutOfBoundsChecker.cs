using UnityEngine;
using UnityEngine.Events;

namespace ParallelWorlds
{
    /// <summary>
    /// Checks if this object is out of bounds.
    /// </summary>
    public class OutOfBoundsChecker : MonoBehaviour
    {
        [SerializeField] private float boundsPosition = -10f;
        [SerializeField] private UnityEvent onOutOfBounds = null;

        private bool debounce = false;

        private void Update()
        {
            if (debounce || transform.position.y > boundsPosition) return;
            debounce = true;
            onOutOfBounds.Invoke();
        }

        public void ResetDebounce()
        {
            debounce = false;
        }
    }
}
