using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ParallelWorlds
{
    /// <summary>
    /// pans audiosources left/right depending on location
    /// </summary>
    public class AudioPanner : MonoBehaviour
    {
        [SerializeField] private AudioSource[] audioSources = null;

        private const float minX = -8.8f;
        private const float maxX = 8.8f;
        private const float panAmount = 0.5f;

        private void Update()
        {
            // -8.8 to 8.8
            float posX = transform.position.x;
            float lerpAmount = (posX - minX) / (maxX - minX) * 2f - 0.5f;
            lerpAmount *= panAmount;

            foreach(AudioSource audioSource in audioSources)
            {
                audioSource.panStereo = lerpAmount;
            }
        }
    }
}
