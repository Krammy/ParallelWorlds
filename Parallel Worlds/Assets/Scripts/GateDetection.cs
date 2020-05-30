using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ParallelWorlds
{
    public class GateDetection : MonoBehaviour
    {
        private bool debounce = false;
        [System.Serializable] private class UnityEventVector2 : UnityEvent<Vector2> {}
        [SerializeField] private UnityEventVector2 onHitGate = null;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (debounce || !other.CompareTag("Gate")) return;
            debounce = true;
            
            Vector2 pos = other.transform.position;
            onHitGate.Invoke(pos);
        }
    }
}
