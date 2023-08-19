using System;
using UnityEngine;

[RequireComponent(typeof(PathChooser))]
public class RoadBuilder : MonoBehaviour
{
    [SerializeField] private Road _road;
    [SerializeField] private Road _turnRoad;

    private Tile[,] _spawnedTiles;
    private Vector2Int _mapSize;

    private Vector2Int _currentPosition;
    private Tile _currentTile;

    private PathChooser _pathChooser;

    public event Func<Road, Transform, Quaternion, int, int, Road> BuildRoad;
    public event Action Finished;

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

    public void InitMap(Tile[,] spawnedTiles, Vector2Int mapSize)
    {
        _spawnedTiles = spawnedTiles;
        _mapSize = mapSize;
    }

    public void InitStart(int positionX, int positionY)
    {
        _currentPosition = new Vector2Int(positionX, positionY);
        _currentTile = null;
    }

    private void OnMove(Vector2Int direction)
    {
        int nextX = _currentPosition.x + direction.x;
        int nextY = _currentPosition.y + direction.y;

        if (nextX >= 0 && nextX < _mapSize.x && nextY >= 0 && nextY < _mapSize.y)
        {
            Tile tile = _spawnedTiles[nextX, nextY];

            if (tile is End)
                Finished?.Invoke();

            if (tile is not InterestTile && tile is not Road)
            {
                Road road = _road;

                Quaternion quaternion = Quaternion.identity;

                if (direction.x == -1)
                {
                    if (_currentTile == _road)
                    {
                        quaternion = Quaternion.Euler(0, -90, 0);
                        var turnroad = BuildRoad?.Invoke(_turnRoad, _currentTile.transform, quaternion, _currentPosition.x, _currentPosition.y);
                        _spawnedTiles[_currentPosition.x, _currentPosition.y] = turnroad;
                    }
                }
                else if (direction.x == -1)
                {
                    if (_currentTile == _road)
                    {
                        quaternion = Quaternion.Euler(0, 180, 0);
                        var turnroad = BuildRoad?.Invoke(_turnRoad, _currentTile.transform, quaternion, _currentPosition.x, _currentPosition.y);
                        _spawnedTiles[_currentPosition.x, _currentPosition.y] = turnroad;
                    }
                    else
                    {

                    }
                }

                var newRoad = BuildRoad?.Invoke(road, tile.transform, quaternion, nextX, nextY);
                _spawnedTiles[nextX, nextY] = newRoad;
                _currentTile = newRoad;
                _currentPosition = new Vector2Int(nextX, nextY);
            }
        }
    }
}