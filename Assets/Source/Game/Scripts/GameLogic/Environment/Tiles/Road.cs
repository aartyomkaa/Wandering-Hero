namespace GameLogic
{
    internal abstract class Road : Tile
    {
        public RoadType Type;

        public abstract RoadType GetRoadType(int x, int y);
    }
}