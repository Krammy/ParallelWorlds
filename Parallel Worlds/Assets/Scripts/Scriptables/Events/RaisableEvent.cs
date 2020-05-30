using UnityEngine;

namespace ParallelWorlds
{
    public abstract class RaisableEvent : ScriptableObject
    {
        public abstract void Raise();
    }
}
