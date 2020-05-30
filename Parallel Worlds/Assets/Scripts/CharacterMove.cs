using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ParallelWorlds
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterMove : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private float jumpForce = 10f;

        private Rigidbody2D rb2d = null;

        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            PlayerInput.Instance.OnJump += Jump;
        }

        private void OnDisable()
        {
            if (PlayerInput.Instance == null) return;
            PlayerInput.Instance.OnJump -= Jump;
        }

        private void Jump()
        {
            rb2d.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
        }

        private void FixedUpdate()
        {
            float newSpeed = PlayerInput.Instance.Horizontal * speed * Time.fixedDeltaTime;
            float velocityDiff = newSpeed - rb2d.velocity.x;
            rb2d.AddForce(Vector2.right * velocityDiff, ForceMode2D.Force);
        }
    }
}
