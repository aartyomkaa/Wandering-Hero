using Wanderer;
using UnityEngine;

namespace GameLogic
{
    [RequireComponent(typeof(MapGenerator))]
    [RequireComponent(typeof(RoadBuilder))]
    internal class Map : MonoBehaviour
    {
        [SerializeField] private PlayerMover _playerMover;
        [SerializeField] private PlayerReseter _playerReseter;
        [SerializeField] private MapStyle[] _mapStyles;

        private MapGenerator _mapGenerator;
        private RoadBuilder _roadBuilder;

        private Tile[,] _spawnedTiles;

        private Vector3 _startPosition;
        private Vector2Int _mapSize;

        private int _battleAmount;

        public int BattleAmount => _battleAmount;

        private void Awake()
        {
            _mapGenerator = GetComponent<MapGenerator>();
            _roadBuilder = GetComponent<RoadBuilder>();
        }

        private void OnEnable()
        {
            _roadBuilder.BuildRoad += OnPlaceRoad;
            _roadBuilder.Finished += OnFinish;
        }

        private void Start()
        {
            _roadBuilder.ChangeStyle(_mapStyles[0]);
            _mapGenerator.ChangeStyle(_mapStyles[0]);
        }

        private void OnDisable()
        {
            _roadBuilder.BuildRoad -= OnPlaceRoad;
            _roadBuilder.Finished -= OnFinish;
        }

        public void Init(Tile[,] generatedTiles, Vector2Int mapSize)
        {
            _spawnedTiles = new Tile[mapSize.x, mapSize.y];
            _mapSize = mapSize;

            for (int x = 0; x < mapSize.x; x++)
            {
                for (int y = 0; y < mapSize.y; y++)
                {
                    var tile = Instantiate(generatedTiles[x, y], new Vector3(x, 0, y), generatedTiles[x, y].transform.rotation, transform);

                    if (tile is Start)
                        _startPosition = tile.transform.position;

                    if (tile is Battle)
                        _battleAmount++;

                    _spawnedTiles[x, y] = tile;
                }
            }

            _roadBuilder.Init(_spawnedTiles, mapSize, _startPosition);
            _playerMover.Init(_startPosition);

            _playerReseter.Reset();
        }

        public void Reset()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            _battleAmount = 0;
            _mapGenerator.Reset();
        }

        public void Restart()
        {
            foreach (var tile in _spawnedTiles)
            {
                if (tile.gameObject.activeSelf == false)
                    tile.gameObject.SetActive(true);

                tile.Restart();
            }

            _roadBuilder.Init(_spawnedTiles, _mapSize, _startPosition);
            _playerMover.Init(_startPosition);

            _playerReseter.Reset();
        }

        public void SetLevel(int level)
        {
            _mapGenerator.SetLevel(level);
        }

        private void OnFinish(Vector3 endPosition)
        {
            _playerMover.StartMove(endPosition);
        }

        private void OnPlaceRoad(Vector3 roadPosition, int tilePositionX, int tilePositionY)
        {
            if (_spawnedTiles[tilePositionX, tilePositionY] is not Finish)
                _spawnedTiles[tilePositionX, tilePositionY].gameObject.SetActive(false);

            _playerMover.AddRoad(roadPosition);
        }
    }
}
