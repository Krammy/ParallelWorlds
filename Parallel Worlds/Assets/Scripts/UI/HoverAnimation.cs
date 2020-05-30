using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ParallelWorlds
{
    public class HoverAnimation : MonoBehaviour
    {
        [SerializeField] private float hoverAmount = 1f;
        [SerializeField] private float hoverTime = 1f;

        private float startY = 0f;
        private RectTransform rectTransform = null;

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            startY = rectTransform.anchoredPosition.y;
        }

        private void Update()
        {
            float pos1 = startY + hoverAmount;
            float pos2 = startY - hoverAmount;

            Vector3 newPos = rectTransform.anchoredPosition;
            newPos.y = Mathf.Lerp(pos1, pos2, Mathf.Sin(Mathf.PI * (Time.time / hoverTime))/2f + 0.5f);

            rectTransform.anchoredPosition = newPos;
        }
    }
}
