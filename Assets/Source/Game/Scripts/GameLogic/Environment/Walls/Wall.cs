using UnityEngine;

namespace GameLogic
<<<<<<< HEAD
{
    internal class Wall : MonoBehaviour 
    {
=======
{ 
    internal class Wall : MonoBehaviour 
    {
        [SerializeField] private WallType _type;

        public WallType Type { get { return _type; } }
    }

    public enum WallType
    {
        Straight,
        CornerLeft,
        CornerRight
>>>>>>> NewPatch
    }
}