using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ParallelWorlds
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private GameEvent switchEvent = null;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                switchEvent.Raise();
            }
        }
    }
}
