using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ParallelWorlds
{
    public class Switcher : MonoBehaviour
    {
        [SerializeField] private GameEvent switchEvent = null;

        private void OnEnable()
        {
            PlayerInput.Instance.OnComplete += Switch;
        }

        private void OnDisable()
        {
            if (PlayerInput.Instance == null) return;
            PlayerInput.Instance.OnComplete -= Switch;
        }

        private void Switch()
        {
            if (!PlayerInput.Instance.Switch) return;
            switchEvent.Raise();
        }
    }
}
