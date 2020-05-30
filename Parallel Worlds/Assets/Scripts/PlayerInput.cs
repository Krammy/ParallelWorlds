using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ParallelWorlds
{
    public class PlayerInput : MonoBehaviour
    {
        public delegate void SwitchEvent();
        public event SwitchEvent OnSwitch = null;

        public float Horizontal { get; private set; }
        public bool Jump { get; private set; }
        public bool Switch { get; private set; }

        private static bool applicationIsQuitting = false;

        private static PlayerInput _instance = null;
        public static PlayerInput Instance
        {
            get
            {
                if (applicationIsQuitting) return null;

                if (_instance == null)
                {
                    var go = new GameObject("PlayerInput");
                    _instance = go.AddComponent<PlayerInput>();
                }
                return _instance;
            }
        }

        private void Update()
        {
            Horizontal = Input.GetAxis("Horizontal");
            Jump = Input.GetButtonDown("Jump");

            if (Input.GetButtonDown("Switch"))
            {
                OnSwitch?.Invoke();
            }
        }

        private void OnDestroy()
        {
            applicationIsQuitting = true;
        }
    }
}
