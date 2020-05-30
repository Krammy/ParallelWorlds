using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ParallelWorlds
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterResetter : MonoBehaviour
    {
        [SerializeField] private UnityEvent afterReset = null;

        private Rigidbody2D rb2d = null;

        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        public void ResetCharacter()
        {
            rb2d.velocity = Vector2.zero;
            transform.localPosition = Vector3.zero;

            afterReset.Invoke();
        }
    }
}
