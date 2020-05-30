using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ParallelWorlds
{
    public class PlayerInput : MonoBehaviour
    {
        public delegate void CompleteEvent();
        public event CompleteEvent OnComplete = null;

        public float Horizontal { get; private set; }
        public bool Jump { get; private set; }
        public bool Switch { get; private set; }

        private static PlayerInput _instance = null;
        public static PlayerInput Instance
        {
            get
            {
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
            Switch = Input.GetButtonDown("Switch");

            OnComplete.Invoke();
        }
    }
}
