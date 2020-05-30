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
        [SerializeField] private float groundTolerance = 0.1f;

        private Rigidbody2D rb2d = null;

        private int touchingAmount = 0;

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

            // create raycast
            

            //Vector2 bottomLeft = myPos + new Vector2(-0.45f, -0.5f - groundTolerance);
            //Vector2 topRight = myPos + Vector2.one * 0.45f;
            //Vector2 size = topRight - bottomLeft;

            //Collider2D hit = Physics2D.OverlapBox(transform.position, size, 0f);
            //if (hit == null) return;

            
        }

        private void FixedUpdate()
        {
            float newSpeed = PlayerInput.Instance.Horizontal * speed * Time.fixedDeltaTime;
            float velocityDiff = newSpeed - rb2d.velocity.x;
            rb2d.AddForce(Vector2.right * velocityDiff, ForceMode2D.Force);
        }
    }
}
