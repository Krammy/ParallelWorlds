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

        private int layer = 0;

        private void Awake()
        {
            layer = LayerMask.NameToLayer("Default");
            rb2d = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            PlayerInput.Instance.OnJump += Jump;
            PlayerInput.Instance.OnSwitch += OnSwitch;
        }

        private void OnDisable()
        {
            if (PlayerInput.Instance == null) return;
            PlayerInput.Instance.OnJump -= Jump;
            PlayerInput.Instance.OnSwitch -= OnSwitch;
            // resets ignore collision
            Physics2D.IgnoreLayerCollision(gameObject.layer, layer, false);
        }

        private void FixedUpdate()
        {
            float newSpeed = PlayerInput.Instance.Horizontal * speed * Time.fixedDeltaTime;
            float velocityDiff = newSpeed - rb2d.velocity.x;
            rb2d.AddForce(Vector2.right * velocityDiff, ForceMode2D.Impulse);
        }

        private void Jump()
        {
            // only jump if moving down
            if (rb2d.velocity.y > 0f) return;

            // get contacts
            List<ContactPoint2D> contactPoints = new List<ContactPoint2D>();
            rb2d.GetContacts(contactPoints);

            Vector2 myPos = transform.position;

            // check normals of contacts, discarding others
            foreach (ContactPoint2D contactPoint in contactPoints)
            {
                float rot = Vector2.Angle(Vector2.zero, contactPoint.normal);
                if (rot >= -45f && rot <= 45f)
                {
                    // add jump force
                    rb2d.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
                    return;
                }
            }
        }

        private void OnSwitch()
        {
            StopAllCoroutines();
            StartCoroutine(SwitchCoroutine());
        }

        private IEnumerator SwitchCoroutine()
        {
            Physics2D.IgnoreLayerCollision(gameObject.layer, layer, true);

            SpriteRenderer spriteRend = gameObject.GetComponentInChildren<SpriteRenderer>();

            for (int i = 1; i < 2; i++)
            {
                yield return 0f;
            }

            while (true)
            {
                if (Physics2D.OverlapCircle(transform.position, 0.5f) == null)
                {
                    break;
                }
                yield return 0f;
            }

            Physics2D.IgnoreLayerCollision(gameObject.layer, layer, false);
        }
    }
}
