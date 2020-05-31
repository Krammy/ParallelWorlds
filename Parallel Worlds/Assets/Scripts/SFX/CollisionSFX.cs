using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ParallelWorlds
{
    public class CollisionSFX : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            float multiplier = collision.relativeVelocity.magnitude;
            audioSource.PlayOneShot(audioSource.clip, audioSource.volume * multiplier);
        }
    }
}
