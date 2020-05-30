using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

namespace ParallelWorlds
{
    public class SpiralTransition : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 5f;
        [SerializeField] private float inwardsSpeed = 1f;
        [SerializeField] private float scaleSpeed = 1f;

        [SerializeField] private UnityEvent onFinishAnimation = null;

        public void StartTransition(Vector2 center)
        {
            StartCoroutine(TransitionCoroutine(center));
        }

        private IEnumerator TransitionCoroutine(Vector2 center)
        {
            // get next circle position with increasingly shrinking radius

            while ((Vector2)transform.position != center && transform.localScale != Vector3.zero)
            {
                yield return 0f;
                Vector2 myPos = transform.position;
                
                Vector2 newPos = Quaternion.Euler(0f, 0f, rotationSpeed * Time.deltaTime) * myPos;
                newPos = Vector2.MoveTowards(newPos, center, inwardsSpeed * Time.deltaTime);

                transform.position = newPos;
                transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.zero, scaleSpeed * Time.deltaTime);
            }

            onFinishAnimation.Invoke();
        }
    }
}
