using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ParallelWorlds
{
    public class Ambience : MonoBehaviour
    {
        [Tooltip("The audio fade after each ambience track.")]
        [SerializeField] private float rolloffSeconds = 0.5f;
        [SerializeField] private AudioSource[] audioSources = null;
        private int playingIndex = 0;

        public void Switch()
        {
            SwitchTo((playingIndex + 1) % audioSources.Length);
        }

        public void SwitchTo(int index)
        {
            if (playingIndex == index) return;

            // fade out one audio source, fade in other
            StartCoroutine(FadeOutAudioSource(audioSources[playingIndex]));
            playingIndex = index;

            audioSources[playingIndex].volume = 1f;
            audioSources[playingIndex].Play();
            Debug.Log("Playing AudioSource #" + playingIndex);
        }

        private IEnumerator FadeOutAudioSource(AudioSource audioSource)
        {
            while (audioSource.volume > 0f)
            {
                audioSource.volume = Mathf.Max(audioSource.volume - Time.deltaTime / rolloffSeconds, 0f);
                yield return 0f;
            }
            audioSource.volume = 0f;
            audioSource.Stop();
            Debug.Log("Completed fade out.");
        }
    }
}
