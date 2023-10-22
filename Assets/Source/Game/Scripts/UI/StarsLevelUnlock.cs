using UnityEngine;

namespace UI
{
    internal class StarsLevelUnlock : MonoBehaviour
    {
        [SerializeField] private int _value;

        public int Value => _value;
    }
}