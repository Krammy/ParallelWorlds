using UnityEngine;
using UnityEngine.Events;

namespace ParallelWorlds
{
    [ExecuteInEditMode]
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] private GameEvent _event = null;
        [SerializeField] private UnityEvent response = null;

        private void OnEnable()
        {
            if (_event == null) return;
            _event.RegisterListener(this);
        }

        private void OnDisable()
        {
            if (_event == null) return;
            _event.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            response.Invoke();
        }
    }
}
