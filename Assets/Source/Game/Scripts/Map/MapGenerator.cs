using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Map))]
public class MapGenerator : MonoBehaviour 
{
    [SerializeField] private Vector2Int _mapSize;
    [SerializeField] private InterestTile[] _interestTiles;
    [SerializeField] private List<Tile> _tiles;
    [SerializeField] private List<Level> _levels;

    [SerializeField] private Tile _start;
    [SerializeField] private Tile _end;

    private Tile[,] _spawnedTiles;
    private Level _currentLevel;

    private Map _map;

    private void Start()
    {
        _map = GetComponent<Map>();

        _currentLevel = _levels[0];
        _spawnedTiles = new Tile[_mapSize.x, _mapSize.y];

        Generate();
    }

    public void Reset()
    {
        _spawnedTiles = new Tile[_mapSize.x, _mapSize.y];

        Generate();
    }

    private void Generate()
    {
        GenerateStartAndEndTiles();

        GenerateInterestTiles();

        GenerateTiles();

        _map.Init(_spawnedTiles, _mapSize);
    }

    private void GenerateStartAndEndTiles()
    {
        Vector2Int startPosition = new Vector2Int(Random.Range(0, _mapSize.x), 0);

        AddTile(startPosition.x, startPosition.y, _start);

        Vector2Int endPosition = new Vector2Int(0, _mapSize.y - 1);

        AddTile(endPosition.x, endPosition.y, _end);
    }

    private void GenerateInterestTiles()
    {
        int placedTiles = 0;
        int iterations = 0;
        int maxIterations = _mapSize.x * _mapSize.y;

        bool isWroking = true;

        foreach(var interestTile in _interestTiles)
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

                        isWroking = false;
                    }
                }
            }

            placedTiles = 0;
        }
    }

    private void GenerateTiles()
    {
        for (int x =  0; x < _mapSize.x; x++)
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
        List<float> chances = new List<float>();

        for (int i = 0; i < availableTiles.Count; i++)
        {
            chances.Add(availableTiles[i].Weight);
        }

        float value = Random.Range(0, chances.Sum());
        float sum = 0;

        for (int i = 0; i < chances.Count; i++)
        {
            sum += chances[i];

            if (value < sum)
            {
                return availableTiles[i];
            }
        }

        return availableTiles[availableTiles.Count - 1];
    }

    private int GetTileAmount(Level level, InterestTile tile)
    {
        if (tile is Heal)
            return level.HealAmount;

        if (tile is Battle)
            return level.BattleAmount;

        if (tile is Upgrade) 
            return level.UpgradeAmount;

        throw new Exception("ti che???");
    }
}

[System.Serializable]
public class Level
{
    public int HealAmount;
    public int BattleAmount;
    public int UpgradeAmount = 1;
}