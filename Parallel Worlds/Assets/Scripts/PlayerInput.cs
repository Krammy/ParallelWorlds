using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ParallelWorlds
{
    public class PlayerInput : MonoBehaviour
    {
        public delegate void InputEvent();
        public event InputEvent OnSwitch = null;
        public event InputEvent OnJump = null;

        public float Horizontal { get; private set; }

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
                    DontDestroyOnLoad(go);
                }
                return _instance;
            }
        }

        private void Update()
        {
            Horizontal = Input.GetAxis("Horizontal");

            if (Input.GetButtonDown("Jump"))
            {
                OnJump?.Invoke();
            }

            if (Input.GetButtonDown("Switch"))
            {
                OnSwitch?.Invoke();
            }
        }

        private void OnApplicationQuit()
        {
            applicationIsQuitting = true;
        }
    }
}
