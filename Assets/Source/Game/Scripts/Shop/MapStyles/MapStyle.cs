﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using GameLogic;

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

        public InterestTile GetInterestTile(int index)
        {
            return _interestTiles[index];
        }

        public Wall GetWall(int index)
        {
            return _walls.ElementAt(index);
        }

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
        }

        public void Unlock()
        {
            _isUnlocked = true;
        }
    }
}
