using System.Collections.Generic;
using System.Linq;
using GameLogic;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    internal abstract class MapStyle : MonoBehaviour, IItem
    {
        [SerializeField] private InterestTile[] _interestTiles;
        [SerializeField] private List<Tile> _tiles;
        [SerializeField] private List<Road> _roads;
        [SerializeField] private List<Wall> _walls;

        [SerializeField] private Tile _start;
        [SerializeField] private Tile _end;

<<<<<<< HEAD:Assets/Source/Game/Scripts/GameLogic/Environment/Map/MapStyle.cs
        public int GetInterestTileLenght()
        {
            return _interestTiles.Length;
        }

        public int GetTilesCount()
        {
            return _tiles.Count;
        }

        public int GetRoadsCount()
        {
            return _roads.Count;
        }
=======
        [SerializeField] private Sprite _image;
        [SerializeField] private int _price;

        private bool _isUnlocked;

        public bool IsUnlocked => _isUnlocked;

        public int Price => _price;

        public Sprite Image => _image;

        public int GetInterestTileLenght() { return _interestTiles.Length; }
        public int GetWallsLenght() { return _walls.Count; }
        public int GetTilesCount() { return _tiles.Count; }
        public int GetRoadsCount() { return _roads.Count; }
>>>>>>> NewPatch:Assets/Source/Game/Scripts/Shop/MapStyles/MapStyle.cs

        public InterestTile GetInterestTile(int index)
        {
            return _interestTiles[index];
        }

<<<<<<< HEAD:Assets/Source/Game/Scripts/GameLogic/Environment/Map/MapStyle.cs
=======
        public Wall GetWall(int index)
        {
            return _walls.ElementAt(index);
        }

>>>>>>> NewPatch:Assets/Source/Game/Scripts/Shop/MapStyles/MapStyle.cs
        public Tile GetTile(int index)
        {
            return _tiles.ElementAt(index);
        }

        public Road GetRoad(int index)
        {
            return _roads.ElementAt(index);
        }

        public Tile GetStart()
        {
            return _start;
        }

        public Tile GetEnd()
        {
            return _end;
<<<<<<< HEAD:Assets/Source/Game/Scripts/GameLogic/Environment/Map/MapStyle.cs
=======
        }

        public void Unlock()
        {
            _isUnlocked = true;
>>>>>>> NewPatch:Assets/Source/Game/Scripts/Shop/MapStyles/MapStyle.cs
        }
    }
}