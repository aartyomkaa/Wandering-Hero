using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MapGenerator))]
[RequireComponent(typeof(RoadBuilder))]
public class Map : MonoBehaviour
{
    [SerializeField] private Wanderer _player;

    private MapGenerator _mapGenerator;
    private RoadBuilder _roadBuilder;

    private Queue<Road> _roads = new Queue<Road>();
    private Tile[,] _spawnedTiles;

    private void Awake()
    {
        _mapGenerator = GetComponent<MapGenerator>();
        _roadBuilder = GetComponent<RoadBuilder>();
    }

    private void OnEnable()
    {
        _roadBuilder.BuildRoad += PlaceRoad;
        _roadBuilder.Finished += OnFinish;
    }

    private void OnDisable()
    {
        _roadBuilder.BuildRoad -= PlaceRoad;
        _roadBuilder.Finished -= OnFinish;
    }

    public void Init(Tile[,] generatedTiles, Vector2Int mapSize)
    {
        _spawnedTiles = new Tile[mapSize.x, mapSize.y];

        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                var tile = Instantiate(generatedTiles[x, y], new Vector3(x, 0, y), Quaternion.identity);

                if (tile is Start)
                {
                    _player.Init(new Vector3(tile.transform.position.x, 1, tile.transform.position.y));
                    _roadBuilder.InitStart((int)tile.transform.position.x, (int)tile.transform.position.z);
                }

                tile.transform.parent = gameObject.transform;

                _spawnedTiles[x, y] = tile;
            }
        }

        _roadBuilder.InitMap(_spawnedTiles, mapSize);
    }

    private void OnFinish()
    {
        _player.StartMove(_roads);
    }

    private Road PlaceRoad(Road road, Transform transform, Quaternion quaternion ,int tilePositionX, int tilePositionY)
    {
        Destroy(_spawnedTiles[tilePositionX, tilePositionY].gameObject);

        Road newRoad = Instantiate(road, transform.position, quaternion);

        newRoad.transform.parent = gameObject.transform;

        _roads.Enqueue(newRoad);

        _spawnedTiles[tilePositionX, tilePositionY] = newRoad;

        return newRoad;
    }

    private void Reset()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        _roads.Clear();

        _mapGenerator.Reset();
    }
}