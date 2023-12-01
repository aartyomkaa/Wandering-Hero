using System.Collections.Generic;
using Shop;
using UnityEngine;

namespace GameLogic
{
    internal class WallsBuilder : MonoBehaviour
    {
        private List<Wall> _walls = new List<Wall>();

        private Wall _straight;
        private Wall _cornerLeft;
        private Wall _cornerRight;

        private int _wallOffset = 2;
        private float _sideOffset = 0.135f;
        private float _leftWallOffset = -0.9f;

        public void BuildWalls(Vector2Int mapSize)
        {
            _straight = GetWall(WallType.Straight);
            _cornerLeft = GetWall(WallType.CornerLeft);
            _cornerRight = GetWall(WallType.CornerRight);

            for (int y = 0; y <= mapSize.y; y += _wallOffset)
            {
                if (y == mapSize.y)
                {
                    Instantiate(_cornerLeft, new Vector3(_leftWallOffset, 1, y - _sideOffset), _cornerLeft.transform.rotation, transform);
                }
                else
                {
                    Instantiate(_straight, new Vector3(_leftWallOffset, 1, y), _straight.transform.rotation, transform);
                }
            }

            for (int y = 0; y <= mapSize.y; y += _wallOffset)
            {
                if (y == mapSize.y)
                {
                    Instantiate(_cornerRight, new Vector3(mapSize.x - _sideOffset, 1, y - _sideOffset), _cornerRight.transform.rotation, transform);
                }
                else
                {
                    Instantiate(_straight, new Vector3(mapSize.x - _sideOffset, 1, y), _straight.transform.rotation, transform);
                }
            }

            for (int x = 0; x < mapSize.x; x += _wallOffset)
            {
                Instantiate(_straight, new Vector3(x, 1, mapSize.y - _sideOffset), Quaternion.identity, transform);
            }
        }

        public void ChangeStyle(MapStyle style)
        {
            _walls.Clear();

            for (int i = 0; i < style.GetWallsLenght(); i++)
            {
                _walls.Add(style.GetWall(i));
            }
        }

        public void Reset()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }

        private Wall GetWall(WallType wallType)
        {
            foreach(Wall wall in _walls)
            {
                if (wall.Type == wallType)
                    return wall;
            }

            throw new System.Exception("No walls???");
        }
    }
}