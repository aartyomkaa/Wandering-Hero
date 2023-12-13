using Constants;
using UnityEngine;

namespace GameLogic
{
    internal class Common : Tile
    {
        private void Start()
        {
            gameObject.transform.localEulerAngles = StaticVariables.TileRotations[Random.Range(0, StaticVariables.TileRotations.Length)];
        }

        public override void Highlight()
        {
            base.Highlight();
        }

        public override void Restart()
        {
            base.Restart();
        }
    }
}