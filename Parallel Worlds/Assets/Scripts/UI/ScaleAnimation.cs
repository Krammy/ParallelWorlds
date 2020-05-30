using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ParallelWorlds
{
    public class ScaleAnimation : MonoBehaviour
    {
        [SerializeField] private float scaleAmount = 1f;
        [SerializeField] private float scaleTime = 1f;

        private float startScale = 0f;

        private void OnEnable()
        {
            startScale = transform.localScale.x;
        }

        private void Update()
        {
            float scale1 = startScale + scaleAmount;
            float scale2 = startScale - scaleAmount;

            Vector2 newScale = Vector2.one * Mathf.Lerp(scale1, scale2, Mathf.Sin(Mathf.PI * (Time.time / scaleTime)) / 2f + 0.5f);

            transform.localScale = new Vector3(newScale.x, newScale.y, transform.localScale.z);
        }
    }
}
