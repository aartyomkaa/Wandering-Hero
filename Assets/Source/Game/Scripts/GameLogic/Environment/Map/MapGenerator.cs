using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameLogic
{
    [RequireComponent(typeof(Map))]
    public class MapGenerator : MonoBehaviour
    {
        [SerializeField] private InterestTile[] _interestTiles;
        [SerializeField] private List<Tile> _tiles;
        [SerializeField] private List<Level> _levels;
        [SerializeField] private WallsBuilder _wallsBuilder;

        [SerializeField] private Tile _start;
        [SerializeField] private Tile _end;

        private Vector2Int _mapSize;
        private Tile[,] _spawnedTiles;
        private Level _currentLevel;

        private Map _map;

        public event Action<Level> LevelChanged;

        private void Awake()
        {
            _map = GetComponent<Map>();
        }

        private void Start()
        {
            _currentLevel = _levels[0];
            LevelChanged?.Invoke(_currentLevel);
            _spawnedTiles = new Tile[_mapSize.x, _mapSize.y];
        }

        public void SetLevel(int level)
        {
            if (_levels.Count >= level)
            {
                _currentLevel = _levels[level - 1];
                LevelChanged?.Invoke(_currentLevel);
            }
        }

        public void Reset()
        {
            if (_mapSize != _currentLevel.MapSize)
            {
                _mapSize = _currentLevel.MapSize;
                _wallsBuilder.Reset();
                _wallsBuilder.BuildWalls(_mapSize);
            }

            _spawnedTiles = new Tile[_mapSize.x, _mapSize.y];

            Generate();
        }

        private void Generate()
        {
            GenerateStartAndEndTiles();

            if (TryGenerateInterestTiles())
            {
                GenerateTiles();

                _map.Init(_spawnedTiles, _mapSize);
            }
        }

        private void GenerateStartAndEndTiles()
        {
            Vector2Int startPosition = new Vector2Int(Random.Range(0, _mapSize.x), 0);

            AddTile(startPosition.x, startPosition.y, _start);

            Vector2Int endPosition = new Vector2Int(0, _mapSize.y - 1);

            AddTile(endPosition.x, endPosition.y, _end);
        }

        private bool TryGenerateInterestTiles()
        {
            int placedTiles = 0;
            int iterations = 0;
            int maxIterations = _mapSize.x * _mapSize.y;

            bool isWroking = true;

            foreach (var interestTile in _interestTiles)
            {
                while (GetTileAmount(_currentLevel, interestTile) > placedTiles && isWroking)
                {
                    Vector2Int position = new Vector2Int(Random.Range(0, _mapSize.x - 1), Random.Range(0, _mapSize.y - 1));

                    if (HaveSpace(position))
                    {
                        AddTile(position.x, position.y, interestTile);

                        placedTiles++;
                    }
                    else
                    {
                        iterations++;

                        if (iterations >= maxIterations)
                        {
                            Reset();

                            return false;
                        }
                    }
                }

                placedTiles = 0;
            }

            return true;
        }

        private void GenerateTiles()
        {
            for (int x = 0; x < _mapSize.x; x++)
            {
                for (int y = 0; y < _mapSize.y; y++)
                {
                    if (_spawnedTiles[x, y] == null)
                    {
                        Tile randomTile = GetRandomTile(_tiles);

                        AddTile(x, y, randomTile);
                    }
                }
            }
        }

        private void AddTile(int x, int y, Tile tile)
        {
            _spawnedTiles[x, y] = tile;
        }

        private bool HaveSpace(Vector2Int position)
        {
            int indentRange = 2;

            int startX = Mathf.Max(position.x - indentRange, 0);
            int endX = Mathf.Min(position.x + indentRange, _mapSize.x - 1);

            int startY = Mathf.Max(position.y - indentRange, 0);
            int endY = Mathf.Min(position.y + indentRange, _mapSize.y - 1);

            for (int x = startX; x <= endX; x++)
            {
                for (int y = startY; y <= endY; y++)
                {
                    if (_spawnedTiles[x, y] is InterestTile)
                        return false;
                }
            }

            return true;
        }

        private Tile GetRandomTile(List<Tile> availableTiles)
        {
            float value = Random.Range(0, availableTiles.Count);

            for (int i = 0; i < availableTiles.Count; i++)
            {
                if (i == value)
                    return availableTiles[i];
            }

            throw new Exception();
        }

        private int GetTileAmount(Level level, InterestTile tile)
        {
            if (tile is Heal)
                return level.HealAmount;

            if (tile is Battle)
                return level.BattleAmount;

            if (tile is Upgrade)
                return level.UpgradeAmount;

            throw new Exception();
        }
    }

    [System.Serializable]
    public class Level
    {
        public Vector2Int MapSize;
        public int HealAmount;
        public int BattleAmount;
        public int UpgradeAmount = 1;
        public Vector3 CameraPosition;
        public Quaternion CameraRotation;
        public Vector3 MobilePortretCameraPosition;
        public Vector3 MobilePortretCameraRotation;
    }
}