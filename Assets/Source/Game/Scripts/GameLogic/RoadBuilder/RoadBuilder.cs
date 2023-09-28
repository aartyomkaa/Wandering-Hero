using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameLogic
{
    [RequireComponent(typeof(PathChooser))]
    public class RoadBuilder : MonoBehaviour
    {
        [SerializeField] private Road _road;
        [SerializeField] private List<Road> _roads;

        [SerializeField] private AudioController _controller;

        private List<Road> _roadList = new List<Road>();
        private Tile[,] _spawnedTiles;

        private Vector2Int _mapSize;
        private Vector2Int _currentPosition;
        private Road _currentRoad;

        private PathChooser _pathChooser;
        private Roadfinder _roadFinder;

        private bool _hasFinished;
        private bool _hasStuck;

        public bool HasStuck => _hasStuck;

        public event Action<Vector3, int, int> BuildRoad;
        public event Action<Vector3> Finished;
        public event Action Stuck;

        private void Awake()
        {
            _pathChooser = GetComponent<PathChooser>();
        }

        private void OnEnable()
        {
            _pathChooser.Moved += OnMove;
        }

        private void OnDisable()
        {
            _pathChooser.Moved -= OnMove;
        }

        public void Init(Tile[,] spawnedTiles, Vector2Int mapSize, Vector3 startPos)
        {
            _spawnedTiles = new Tile[mapSize.x, mapSize.y];
            _mapSize = mapSize;
            Array.Copy(spawnedTiles, _spawnedTiles, spawnedTiles.Length);

            if (_roadList.Count > 0)
            {
                foreach (var road in _roadList)
                {
                    Destroy(road.gameObject);
                }
            }

            _roadList.Clear();
            _currentRoad = _road;
            _hasFinished = false;
            _hasStuck = false;

            _currentPosition = new Vector2Int((int)startPos.x, (int)startPos.z);
        }

        private void OnMove(Vector2Int direction)
        {
            if (CanMove(_currentPosition) == false)
            {
                Stuck?.Invoke();
                _hasStuck = true;

                return;
            }

            int nextX = _currentPosition.x + direction.x;
            int nextY = _currentPosition.y + direction.y;

            if ((nextX >= 0 && nextX < _mapSize.x) && (nextY >= 0 && nextY < _mapSize.y) && _hasFinished == false)
            {
                Tile nextTile = _spawnedTiles[nextX, nextY];

                if (nextTile is Finish)
                {
                    PlaceRoad(direction, nextX, nextY);
                    BuildRoad?.Invoke(nextTile.transform.position, _currentPosition.x, _currentPosition.y);

                    Finished?.Invoke(nextTile.transform.position);

                    _hasFinished = true;
                }

                if (nextTile is not InterestTile && nextTile is not Road)
                {
                    nextTile.Highlight();

                    PlaceRoad(direction, nextX, nextY);
                }
            }
        }

        private void PlaceRoad(Vector2Int direction, int nextX, int nextY)
        {
            _roadFinder = new Roadfinder(_currentRoad);

            RoadType nextRoadType = _roadFinder.Find(direction.x, direction.y);

            Road road = _roads.FirstOrDefault(r => r.Type == nextRoadType);

            if (road != null)
            {
                Road newRoad = Instantiate(road, new Vector3(_currentPosition.x, 0, _currentPosition.y), road.transform.rotation, transform);
                _roadList.Add(newRoad);
                BuildRoad?.Invoke(newRoad.transform.position, _currentPosition.x, _currentPosition.y);

                _spawnedTiles[_currentPosition.x, _currentPosition.y] = newRoad;
                _currentPosition = new Vector2Int(nextX, nextY);
                _currentRoad = newRoad;

                _controller.Play(Constants.StaticVariables.PlaceRoadSound);
            }
        }

        private bool CanMove(Vector2Int position)
        {
            int indentRange = 1;

            int startX = Mathf.Max(position.x - indentRange, 0);
            int endX = Mathf.Min(position.x + indentRange, _mapSize.x - 1);

            int startY = Mathf.Max(position.y - indentRange, 0);
            int endY = Mathf.Min(position.y + indentRange, _mapSize.y - 1);

            for (int x = startX; x <= endX; x++)
            {
                for (int y = startY; y <= endY; y++)
                {
                    if (new Vector2Int(x, y) != _currentPosition)
                    {
                        if (_spawnedTiles[x, y] is not InterestTile && _spawnedTiles[x, y] is not Road)
                            return true;
                    }
                }
            }

            return false;
        }
    }
}