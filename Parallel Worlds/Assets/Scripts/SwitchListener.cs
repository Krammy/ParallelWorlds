using UnityEngine;
using UnityEngine.Events;

namespace ParallelWorlds
{
    public class SwitchListener : MonoBehaviour
    {
        [SerializeField] private UnityEvent onSwitch = null;

        private void OnEnable()
        {
            PlayerInput.Instance.OnSwitch += OnSwitch;
        }

        private void OnDisable()
        {
            if (PlayerInput.Instance == null) return;
            PlayerInput.Instance.OnSwitch -= OnSwitch;
        }

        private void OnSwitch()
        {
            onSwitch.Invoke();
        }
    }
}
