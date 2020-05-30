using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ParallelWorlds
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterMove : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;

        private Rigidbody2D rb2d = null;

        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            float newSpeed = PlayerInput.Instance.Horizontal * speed * Time.fixedDeltaTime;
            float velocityDiff = newSpeed - rb2d.velocity.x;
            rb2d.AddForce(Vector2.right * velocityDiff, ForceMode2D.Force);
        }
    }
}
