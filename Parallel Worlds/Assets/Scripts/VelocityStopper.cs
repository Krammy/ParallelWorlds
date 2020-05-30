using UnityEngine;

namespace ParallelWorlds
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class VelocityStopper : MonoBehaviour
    {
        private Rigidbody2D rb2d = null;

        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        public void StopVelocity()
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}