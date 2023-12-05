using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameLogic
{
    internal abstract class MapStyle : MonoBehaviour
    {
        [SerializeField] private InterestTile[] _interestTiles;
        [SerializeField] private List<Tile> _tiles;
        [SerializeField] private List<Road> _roads;

        [SerializeField] private Tile _start;
        [SerializeField] private Tile _end;

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

        public InterestTile GetInterestTile(int index)
        {
            return _interestTiles[index];
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
            return _start;
        }
    }
}