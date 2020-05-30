using UnityEngine;
using UnityEditor;

namespace ParallelWorlds
{
    [CustomEditor(typeof(RaisableEvent), true)]
    public class RaisableEventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            RaisableEvent myEvent = (RaisableEvent)target;

            if (GUILayout.Button("Raise"))
            {
                myEvent.Raise();
            }

            base.OnInspectorGUI();
        }
    }
}