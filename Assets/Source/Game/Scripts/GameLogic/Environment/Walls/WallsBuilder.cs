using UnityEngine;

namespace GameLogic
{
    internal class WallsBuilder : MonoBehaviour
    {
        [SerializeField] private Wall _straightWall;
        [SerializeField] private Wall _cornerWallLeft;
        [SerializeField] private Wall _cornerWallRight;

        private int _wallOffset = 2;
        private float _sideOffset = 0.135f;
        private float _leftWallOffset = 0.9f;

        public void BuildWalls(Vector2Int mapSize)
        {
            for (int y = 0; y <= mapSize.y; y += _wallOffset)
            {
                if (y == mapSize.y)
                {
                    Instantiate(_cornerWallLeft, new Vector3(_leftWallOffset, 1, y - _sideOffset), _cornerWallLeft.transform.rotation, transform);
                }
                else
                {
                    Instantiate(_straightWall, new Vector3(-_leftWallOffset, 1, y), _straightWall.transform.rotation, transform);
                }
            }

            for (int y = 0; y <= mapSize.y; y += _wallOffset)
            {
                if (y == mapSize.y)
                {
                    Instantiate(_cornerWallRight, new Vector3(mapSize.x - _sideOffset, 1, y - _sideOffset), _cornerWallRight.transform.rotation, transform);
                }
                else
                {
                    Instantiate(_straightWall, new Vector3(mapSize.x - _sideOffset, 1, y), _straightWall.transform.rotation, transform);
                }
            }

            for (int x = 0; x < mapSize.x; x += _wallOffset)
            {
                Instantiate(_straightWall, new Vector3(x, 1, mapSize.y - _sideOffset), Quaternion.identity, transform);
            }
        }

        public void Reset()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}